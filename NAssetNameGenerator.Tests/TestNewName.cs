using NAssetNameGenerator;
using NUnit.Framework;
using System.Text.RegularExpressions;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void NewNameIsNotNull()
        {
            // Validate that a non-null string is returned from name generator.
            Assert.IsNotNull(AssetName.NewName());
        }

        [Test]
        public void NewNameDoesNotContainDigitsByDefault()
        {
            // Test default constructor does not include digits
            Assert.True(Regex.IsMatch(AssetName.NewName(), "^[a-z]*_[a-z]*$"));

            // Test any number less than or equal to 0 will result in a non-digit string.
            Assert.True(Regex.IsMatch(AssetName.NewName(-100), "^[a-z]*_[a-z]*$"));
            Assert.True(Regex.IsMatch(AssetName.NewName(0), "^[a-z]*_[a-z]*$"));
        }

        [Test]
        public void NewNameContainsCorrectNumberOfDigits()
        {
            // Test default constructor includes the proper # of digits.
            // Verify that the max # of digits is capped at int.max.
            for (int i = 1; i < 1000; i++)
            {
                Assert.True(Regex.IsMatch(AssetName.NewName(i), $@"^[a-z]*_[a-z]*_\d{{{i}}}$"));
            }
        }
    }
}