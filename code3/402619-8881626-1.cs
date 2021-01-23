            [Test]
        public void CultureTest()
        {
            var c = CultureInfo.CreateSpecificCulture("nb-NO");
            Assert.AreEqual("Norwegian, Bokmål (Norway)",c.DisplayName);
            Assert.AreEqual("nb-NO", c.Name);
            Assert.AreEqual("norsk, bokmål (Norge)", c.NativeName);
            var c2 =
                CultureInfo.CreateSpecificCulture("nb");
            Assert.AreEqual("Norwegian, Bokmål (Norway)", c2.DisplayName);
            Assert.AreEqual("nb-NO", c2.Name);
            Assert.AreEqual("norsk, bokmål (Norge)", c2.NativeName);
            var c3 =
                CultureInfo.CreateSpecificCulture("NO");
            Assert.AreEqual("Norwegian, Bokmål (Norway)", c3.DisplayName);
            Assert.AreEqual("nb-NO", c3.Name);
            Assert.AreEqual("norsk, bokmål (Norge)", c3.NativeName);
           
        }
