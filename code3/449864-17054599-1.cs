        [TestMethod()]
        public void IsValidGtinTest_Valid()
        {
            string[] valid = new[] {
                "085126880552",
                "0085126880552",
                "00085126880552",
                "0786936226355",
                "0719852136552"
            };
            foreach (var upc in valid)
                Assert.IsTrue(IdentifierUtilities.IsValidGtin(upc), upc);
        }
        [TestMethod()]
        public void IsValidGtinTest_Invalid()
        {
            string[] invalid = new[] {
                "0058126880552",
                "58126880552",
                "0786936223655",
                "0719853136552",
                "",
                "00",
                null,
                "123456789123456789123456789",
                "1111111111111"
            };
            foreach (var upc in invalid)
                Assert.IsFalse(IdentifierUtilities.IsValidGtin(upc), upc);
        }
