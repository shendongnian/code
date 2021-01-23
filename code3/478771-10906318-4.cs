        [TestMethod]
        public void TestDispose()
        {
            var m = new MemoryStream();
            m.WriteByte(120);
            m.Dispose();
            var a = m.ToArray();
            Assert.AreEqual(1, a.Length);
        }
