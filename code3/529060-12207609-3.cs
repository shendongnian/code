    List<Sample> samples = new List<Sample>();
    Dictionary<string, object> data = ser.DeserializeObject(json) as Dictionary<string, object>;
    var keys =  data.Keys.ToList();
    for (int i = 0; i <keys.Count; i++)
    {
        string k = keys[i];
        if (Regex.IsMatch(k, "^statistics/sample(@\\d*)?$"))
        {
            samples.Add(new Sample
            {
                Date = (string)data[keys[i + 1]],
                Duration = double.Parse((string)data[keys[i + 2]])
            });
        }
    }
