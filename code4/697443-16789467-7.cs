    string json = ...; //your json goes here
	var serializer = new JavaScriptSerializer();
	var parsed =  serializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(json);
    //printing data
	parsed["0"].Select(pair => string.Format( "{0} - {1}", pair.Key, pair.Value))
			   .ToList()
			   .ForEach(Console.WriteLine);
