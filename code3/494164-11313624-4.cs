        [TestMethod]
        public void ExpandoObjectSerializesToJsonArray()
        {
            dynamic anonType = new { Value = 10, Product = "Apples" };
            dynamic expando = new ExpandoObject();
            expando.Value = 10;
            expando.Product = "Apples";
            var anonResult = System.Web.Helpers.Json.Encode(anonType);
            var expandoResult = System.Web.Helpers.Json.Encode(expando);
            Assert.AreEqual("{\"Value\":10,\"Product\":\"Apples\"}", anonResult);
            Assert.AreEqual("[{\"Key\":\"Value\",\"Value\":10},{\"Key\":\"Product\",\"Value\":\"Apples\"}]", expandoResult);
        }
