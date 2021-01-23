    var values = JsonConvert.DeserializeObject<Dictionary<string, string>[]>(data);
    foreach (var element in values)
    {
        foreach (string entry in element)
        {
            System.Diagnostics.Debug.Print("'{0}', '{1}'",
                entry.Key,
                entry.Value
            );
        }
    }
