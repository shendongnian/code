    foreach (string  key in dict.Keys)
    {
        foreach (string innerKey in dict[key].Keys)
        {
            System.Diagnostics.Debug.WriteLine(dict[key][innerKey]);
        }
    }
