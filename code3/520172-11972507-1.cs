    var obj = (JObject)JsonConvert.DeserializeObject(json);
    foreach (JProperty item in obj["ABCXYZ"].Children())
    {
        Console.WriteLine(item.Name);
        foreach (var x in item)
        {
            foreach (var y in x)
            {
                Console.WriteLine("\t==> " + y[0]);
            }
        }
    }
