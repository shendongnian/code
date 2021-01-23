    Dictionary<string, object> jo = new Dictionary<string, object>();
    jo.Add("CamelCase", 1);
    var settings = new JsonSerializerSettings()
    {
        ContractResolver = new CamelCasePropertyNamesContractResolver()
    };
    var serialized = JsonConvert.SerializeObject(jo, settings);
    Assert.AreEqual("{\"camelCase\":1}", serialized);
