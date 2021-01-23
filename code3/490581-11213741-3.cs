    dynamic dynObj = JsonConvert.DeserializeObject(json);
    foreach(var data in dynObj.Root.data)
    {
        Console.WriteLine("{0}",data.name);
        foreach(var fql in data.fql_result_set)
        {
            foreach (JProperty keyValue in fql)
            {
                Console.WriteLine("\t{0} : {1}", keyValue.Name,keyValue.Value);
            }
        }
    }
