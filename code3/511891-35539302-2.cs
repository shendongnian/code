    string JsonQuery = "{\"Terms\":[{\"Value\":\"This is \"},{\"Variable\":\"X\"},{\"Value\":\"!\"}]}";
    ...
    var query = new Query(new Value("This is "), new Variable("X"), new Value("!"));
    var serializeObject = JsonConvert.SerializeObject(query, new TermConverter());
    Assert.AreEqual(JsonQuery, serializeObject);
    ...
    var queryDeserialized = JsonConvert.DeserializeObject<Query>(JsonQuery, new TermConverter());
