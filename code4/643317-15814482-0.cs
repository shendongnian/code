    [TestClass]
    public class CustomDictionaryJsonSerialization
    {
        [TestMethod]
        public void SerializeDictionary()
        {
            Dictionary<string, object> dict
                = new Dictionary<string, object> {{"col1", 1}, {"col2", "two"}};
            var nameValues = dict.Keys.Select(k =>
                new {ColumnName = k, ColumnValue = dict[k]});
            var toSerialize = new {a = nameValues.ToList()};
            string serialized = JsonConvert.SerializeObject(toSerialize);
            Assert.IsNotNull(serialized);
        }
    }
