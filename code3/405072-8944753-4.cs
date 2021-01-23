        [TestMethod]
        public void TestFormatResolvers()
        {
            RegisterFormatResolvers();
            Assert.AreEqual("yeaaah", GetFormattedAttribute(true));
            Assert.AreEqual("nope", GetFormattedAttribute(false));
            Assert.AreEqual("<b>20120120</b>", GetFormattedAttribute(new DateTime(2012, 01, 20)));
            Assert.AreEqual("5", GetFormattedAttribute(5));
        }
