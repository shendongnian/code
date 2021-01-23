        public static bool IsValidEan13(string eanBarcode)
        {
            return IsValidEan(eanBarcode, 13);
        }
        public static bool IsValidEan12(string eanBarcode)
        {
            return IsValidEan(eanBarcode, 12);
        }
        public static bool IsValidEan14(string eanBarcode)
        {
            return IsValidEan(eanBarcode, 14);
        }
        public static bool IsValidEan8(string eanBarcode)
        {
            return IsValidEan(eanBarcode, 8);
        }
        private static bool IsValidEan(string eanBarcode, int length)
        {
            if (eanBarcode.Length != length) return false;
            var allDigits = eanBarcode.Select(c => int.Parse(c.ToString(CultureInfo.InvariantCulture))).ToArray();
            var s = length%2 == 0 ? 3 : 1;
            var s2 = s == 3 ? 1 : 3;
            return allDigits.Last() == (10 - (allDigits.Take(length-1).Select((c, ci) => c*(ci%2 == 0 ? s : s2)).Sum()%10))%10;
        }
        [Test]
        [TestCaseSource("Ean_13_TestCases")]
        public void Check_Ean13_Is_Valid(string ean, bool isValid)
        {
            BlinkBuilder.IsValidEan13(ean).Should().Be(isValid);
        }
        private static IEnumerable<object[]> Ean_13_TestCases()
        {
            yield return new object[] { "9781118143308", true };
            yield return new object[] { "978111814330", false };
            yield return new object[] { "97811181433081", false };
            yield return new object[] { "5017188883399", true };
        }
        [Test]
        [TestCaseSource("Ean_8_TestCases")]
        public void Check_Ean8_Is_Valid(string ean, bool isValid)
        {
            BlinkBuilder.IsValidEan8(ean).Should().Be(isValid);
        }
        private static IEnumerable<object[]> Ean_8_TestCases()
        {
            yield return new object[] { "12345670", true };
            yield return new object[] { "12345679", false };
            yield return new object[] { "55432214", true  };
            yield return new object[] { "55432213", false };
            yield return new object[] { "55432215", false };
        }
