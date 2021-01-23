    var parsed = JsonConvert.DeserializeObject<JObject>("{\"name\":{\"a\":2, \"b\":\"a string\", \"c\":3 } }");
    foreach (var property in parsed.Properties()) {
        Console.WriteLine(property.Name);
    	foreach (var innerProperty in ((JObject)property.Value).Properties()) {
    		Console.WriteLine("\t{0}: {1}", innerProperty.Name, innerProperty.Value.ToObject<object>());
    	}
    }
