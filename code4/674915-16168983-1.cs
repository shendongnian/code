    List<string> metadata = new List<string>();//string list
    metadata.Add("itemname");
    metadata.Add("soid");
    metadata.Add("qty");
    metadata.Add("yada");
    var result = from str in metadata
                 join prop in typeof(Input).GetProperties() on str equals prop.Name
                 select str;
    foreach (string prop in result)
    {
        Console.WriteLine(prop);
    }
