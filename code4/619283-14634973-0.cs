        [TestMethod]
        public void Test()
        {
            const string sample1 = "aabcd123";
            const string sample2 = "aaabcd123";
            const string sample3 = "aabbab11!@";
            const string sample4 = "aabbbac123!";
            Assert.IsTrue(IsOk(sample1));
            Assert.IsFalse(IsOk(sample2));
            Assert.IsTrue(IsOk(sample3));
            Assert.IsFalse(IsOk(sample4));
        }
        private bool IsOk(string str)
        {
            char? last = null;
            var i = 1;
            foreach (var c in str)
            {
                if (last == c)
                {
                    i++;
                    if (i > 2) return false;
                }
                else
                {
                    i = 1;
                }
                last = c;
            }
            return true;
        }
