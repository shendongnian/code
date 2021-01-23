        [TestMethod]
        public void TestMethod1()
        {
            dynamic expando = new ExpandoObject();
            expando.Value = 10;
            expando.Product = "Apples";
            var dictionaryResult = System.Web.Helpers.Json.Encode(new DynamicJsonObject(expando));
            Assert.AreEqual("{\"Value\":10,\"Product\":\"Apples\"}", dictionaryResult);
        }
