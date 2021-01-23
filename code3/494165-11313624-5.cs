        [TestMethod]
        public void TestMethod1()
        {
            dynamic expando = new ExpandoObject();
            expando.Value = 10;
            expando.Product = "Apples";
            // copy expando properties to dictionary
            var dictionary = ((ExpandoObject)expando).ToDictionary(x => x.Key, x => x.Value);
            var expandoResult    = System.Web.Helpers.Json.Encode(expando);
            var dictionaryResult = System.Web.Helpers.Json.Encode(dictionary);
            Assert.AreEqual("[{\"Key\":\"Value\",\"Value\":10},{\"Key\":\"Product\",\"Value\":\"Apples\"}]", expandoResult);
            Assert.AreEqual("{\"Value\":10,\"Product\":\"Apples\"}", dictionaryResult);
        }
