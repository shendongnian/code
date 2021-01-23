        [Test]
        public void TestC()
        {
            string input = "[A].[B].[C].[D].[X].[Y]";
            string actual = Regex.Match(input, @"(?<=\[)\w(?=\]\.\[D\])").Value;
            string expected = "C";
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void TestY()
        {
            string input = "[A].[B].[C].[D].[X].[Y]";
            string actual = Regex.Match(input, @"(?<=\[X\]\.\[)\w(?=\])").Value;
            string expected = "Y";
            Assert.AreEqual(expected, actual);
        }
