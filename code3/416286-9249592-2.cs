	var settings = new JsonSerializerSettings()
					   {
						   ContractResolver = new CamelCasePropertyNamesContractResolver(),
						   Converters = new List<JsonConverter> { new CamelCaseToPascalCaseExpandoObjectConverter() }
					   };
	var json = "{\"someProperty\":\"some value\"}";
	
	dynamic deserialized = JsonConvert.DeserializeObject<ExpandoObject>(json, settings);
	Console.WriteLine(deserialized.SomeProperty); //some value
	var json2 = JsonConvert.SerializeObject(deserialized, Formatting.None, settings);
	Console.WriteLine(json == json2); //true
