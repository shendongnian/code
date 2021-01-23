        [Test]
        public void TrimTest()
        {
            var str = "OG000134W4.11";
            var ret = str.SkipWhile(x => char.IsLetter(x) || x == '0').TakeWhile(x => !char.IsLetter(x));
            Assert.AreEqual("134", ret);
        }
