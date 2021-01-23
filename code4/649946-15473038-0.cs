    Container container = new Container
    {
        Data = new Dictionary<string, object> { { "Text", "Hello world" } }
    };
    string jsonText = JsonConvert.SerializeObject(container);
    var obj = JsonConvert.DeserializeObject<ExpandoObject>(jsonText, new ExpandoObjectConverter());
