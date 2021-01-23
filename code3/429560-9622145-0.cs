    var settings = new JsonSerializerSettings();
    settings.TypeNameHandling = TypeNameHandling.Auto;
    string stream = JsonConvert.SerializeObject(testObject, Formatting.None, settings);
    // ...
    TestClass result = JsonConvert.DeserializeObject<TestClass>(stream, settings);
