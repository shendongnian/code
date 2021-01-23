        [TestMethod]
        public void CheckTitleTest()
        {
            // Empty
            Assert.IsFalse(CheckTitle(@""));
            // A whitespace
            Assert.IsFalse(CheckTitle(@" "));
            // Multiple whitespace only
            // http://msdn.microsoft.com/en-us/library/t809ektx.aspx
            Assert.IsFalse(CheckTitle("  \t \n \u1680"));
            // Leading whitespaces
            Assert.IsFalse(CheckTitle("  \tabc"));
            // Trailing whitespaces
            Assert.IsFalse(CheckTitle("abc\t "));
            // Leading and trailing whitespaces
            Assert.IsFalse(CheckTitle("  \tabc\t "));
            // Too long: 257 character
            Assert.IsFalse(CheckTitle(@"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/*"));
            // A normal title
            Assert.IsTrue(CheckTitle(@"This is a normal title"));
            Assert.IsTrue(CheckTitle(@"This is a normal title."));
            // 256 characters
            Assert.IsTrue(CheckTitle(@"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/"));
            // A very simple title
            Assert.IsTrue(CheckTitle(@"A"));
            Assert.IsTrue(CheckTitle(@"!"));
            Assert.IsTrue(CheckTitle(@"\"));
        }
