        [TestFixture]
    public class RomanNumeralsTests
    {
        [Test]
        public void TranslateRomanNumeral_WhenArgumentIsNull_RaiseArgumentNullException()
        {
            var romanNumerals = new RomanNumerals();
            Assert.Throws<ArgumentException>(() => romanNumerals.TranslateRomanNumeral(null));
        }
        [TestCase("A")]
        [TestCase("-")]
        [TestCase("BXA")]
        [TestCase("MMXK")]
        public void TranslateRomanNumeral_WhenInvalidNumeralSyntax_RaiseException(string input)
        {
            var romanNumerals = new RomanNumerals();
            Assert.Throws<ArgumentException>(() => romanNumerals.TranslateRomanNumeral(input));
        }
        [TestCase("IIII")]
        [TestCase("CCCC")]
        [TestCase("VV")]
        [TestCase("IC")]
        [TestCase("IM")]
        [TestCase("XM")]
        [TestCase("IL")]
        [TestCase("MCDXCXI")]
        [TestCase("MCDDXC")]
        public void TranslateRomanNumeral_WhenInvalidNumeralSemantics_RaiseException(string input)
        {
            var romanNumerals = new RomanNumerals();
            Assert.Throws<ArgumentException>(() => romanNumerals.TranslateRomanNumeral(input));
        }
        [TestCase("I", 1)]
        [TestCase("II", 2)]
        [TestCase("III", 3)]
        [TestCase("IV", 4)]
        [TestCase("XLII", 42)]
        [TestCase("MMXIII", 2013)]
        [TestCase("MXI", 1011)]
        [TestCase("MCDXCIX", 1499)]
        [TestCase("MMXXII", 2022)]
        [TestCase("V", 5)]
        [TestCase("VI", 6)]
        [TestCase("CX", 110)]
        [TestCase("CCCLXXV", 375)]
        [TestCase("MD", 1500)]
        [TestCase("MDLXXV", 1575)]
        [TestCase("MDCL", 1650)]
        [TestCase("MDCCXXV", 1725)]
        [TestCase("MDCCC", 1800)]
        [TestCase("MDCCCLXXV", 1875)]
        [TestCase("MCML", 1950)]
        [TestCase("MMXXV", 2025)]
        [TestCase("MMC", 2100)]
        [TestCase("MMCLXXV", 2175)]
        [TestCase("MMCCL", 2250)]
        [TestCase("MMCCCXXV", 2325)]
        [TestCase("MMCD", 2400)]
        [TestCase("MMCDLXXV", 2475)]
        [TestCase("MMDL", 2550)]
        [TestCase("MMMMMMMM", 8000)]
        [TestCase("MMMMMMMMIV", 8004)]
        public void TranslateRomanNumeral_WhenValidNumeral_Translate(string input, int output)
        {
            var romanNumerals = new RomanNumerals();
            var result = romanNumerals.TranslateRomanNumeral(input);
            Assert.That(result.Equals(output));
        }
    }
