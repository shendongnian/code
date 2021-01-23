    void Main()
    {
        var json = System.IO.File.ReadAllText(@"d:\test.json");
        
        JObject root = JObject.Parse(json);
        foreach(KeyValuePair<String, JToken> app in root)
        {
            var appName = app.Key;
            var description = (String)app.Value["Description"];
            var value = (String)app.Value["Value"];
            
            Console.WriteLine(appName);
            Console.WriteLine(description);
            Console.WriteLine(value);
            Console.WriteLine("\n");
        }
    }
