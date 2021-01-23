    string json = ...; //your json goes here
	var serializer = new JavaScriptSerializer();
	var items =  serializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(json);
    //printing data
	items["0"].Select(pair => string.Format( "{0} - {1}", pair.Key, pair.Value))
			  .ToList()
			  .ForEach(Console.WriteLine);
