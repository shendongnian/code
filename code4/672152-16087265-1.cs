    public class OrderedContractResolver : DefaultContractResolver
    {
        protected override System.Collections.Generic.IList<JsonProperty> CreateProperties(System.Type type, MemberSerialization memberSerialization)
        {
            return base.CreateProperties(type, memberSerialization).OrderBy(p => p.PropertyName).ToList();
        }
    }
    public class JsonSerializationTest1
    {
        public string Test1 { get; set; }
        public string MyTest2 { get; set; }
        public string Test2 { get; set; }
        public string Test10 { get; set; }
    }
    public class JsonSerializationTest2
    {
        public string Test10 { get; set; }
        public string Test1 { get; set; }
        public string MyTest2 { get; set; }
        public string Test2 { get; set; }
    }
   
    [TestMethod]
        public void TestJsonOrder()
        {
            var test1 = new JsonSerializationTest1 { Test1 = "abc", MyTest2 = "efg", Test10 = "hij", Test2 = "zyx" };
            var test2 = new JsonSerializationTest2 { Test1 = "abc", Test10 = "hij", Test2 = "zyx", MyTest2 = "efg" };
            var test1Json = JsonConvert.SerializeObject(test1);
            var test2Json = JsonConvert.SerializeObject(test2);
            Assert.AreNotEqual(test1Json, test2Json);
            var settings = new JsonSerializerSettings()
            {
                ContractResolver = new OrderedContractResolver()
            };
            var json1 = JsonConvert.SerializeObject(test1, Formatting.Indented, settings);
            var json2 = JsonConvert.SerializeObject(test2, Formatting.Indented, settings);
            Assert.AreEqual(json1, json2);
        }
