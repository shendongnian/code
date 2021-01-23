    var test = new Test
        {
            X = "123",
            Y = new Dictionary<string, string>
                {
                    { "key1", "value1" },
                    { "key2", "value2" },
                    { "key3", "value3" },
                }
        };
    string json = JsonConvert.SerializeObject(test, Formatting.Indented, new TestObjectConverter());
    var deserializedObject = JsonConvert.DeserializeObject<Test>(json);
