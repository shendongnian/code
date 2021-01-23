    foreach(var line in yourReader)
    {
        var dict = new Dictionary<string,string>(); // your replacement dictionaries
        foreach(var kvp in dict)
        {
            System.Text.RegularExpressions.Regex.Replace(line,"(\s|,|\.|:|\\t)" + kvp.Key + "(\s|,|\.|:|\\t)","\0" + kvp.Value + "\1");
        }
    }
