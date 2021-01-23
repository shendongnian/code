    var jo = new JObject();
    jo["CamelCase"] = 1;
    string json = JsonConvert.SerializeObject(jo);
    var jObject = JsonConvert.DeserializeObject<ExpandoObject>(json);
    var settings = new JsonSerializerSettings()
    {
        ContractResolver = new CamelCasePropertyNamesContractResolver()
    };
    var serialized = JsonConvert.SerializeObject(jObject, settings);
    Assert.AreEqual("{\"camelCase\":1}", serialized);
