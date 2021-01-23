    dynamic jObj = JsonConvert.DeserializeObject(json);
    Console.WriteLine(jObj.Similar.Info[0].Name + "\n");
    foreach (var result in jObj.Similar.Results)
    {
        Console.WriteLine("{0}:{1}",result.Type, result.Name);
    }
