    private const string Json = "{\"id\":7908,\"name\":\"product name\",\"_unknown_field_name_1\":\"some value\",\"_unknown_field_name_2\":\"some value\"}";
        [TestMethod]
        public void TestDeserializeUnknownMembers()
        {
            var @object = ServiceStack.Text.JsonObject.Parse(Json);
            var serializer = new Newtonsoft.Json.JsonSerializer();
            serializer.MissingMemberHandling = Newtonsoft.Json.MissingMemberHandling.Error;
            serializer.Error += (sender, eventArgs) =>
                {
                    var contract = eventArgs.CurrentObject as Contract;
                    contract.UnknownValues.Add(eventArgs.ErrorContext.Member.ToString(), @object[eventArgs.ErrorContext.Member.ToString()]);
                    eventArgs.ErrorContext.Handled = true;
                };
            using (MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(Json)))
            using (StreamReader streamReader = new StreamReader(memoryStream))
            using (JsonReader jsonReader = new JsonTextReader(streamReader))
            {
                var result = serializer.Deserialize<Contract>(jsonReader);
                Assert.IsTrue(result.UnknownValues.ContainsKey("_unknown_field_name_1"));
                Assert.IsTrue(result.UnknownValues.ContainsKey("_unknown_field_name_2"));
            }
        }
        [TestMethod]
        public void TestSerializeUnknownMembers()
        {
            var deserializedObject = new Contract
            {
                id = 7908,
                name = "product name",
                UnknownValues = new Dictionary<string, string>
                {
                    {"_unknown_field_name_1", "some value"},
                    {"_unknown_field_name_2", "some value"}
                }
            };
            var json = JsonConvert.SerializeObject(deserializedObject, new DictionaryConverter());
            Console.WriteLine(Json);
            Console.WriteLine(json);
            Assert.AreEqual(Json, json);
        }
    }
    class DictionaryConverter : JsonConverter
    {
        public DictionaryConverter()
        {
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Contract);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var contract = value as Contract;
            var json = JsonConvert.SerializeObject(value);
            var dictArray = String.Join(",", contract.UnknownValues.Select(pair => "\"" + pair.Key + "\":\"" + pair.Value + "\""));
            json = json.Substring(0, json.Length - 1) + "," + dictArray + "}";
            writer.WriteRaw(json);
        }
    }
    class Contract
    {
        public Contract()
        {
            UnknownValues = new Dictionary<string, string>();
        }
        public int id { get; set; }
        public string name { get; set; }
        [JsonIgnore]
        public Dictionary<string, string> UnknownValues { get; set; }
    }
