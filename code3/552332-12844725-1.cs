    var lines = File.ReadAllLines("path/to/file").Select(l => l.Split(','));
    var dict = new Dictionary<string, List<string>();
    foreach(var splits in lines) 
    {
        var key = splits.First();
        var value = splits.Skip(1).ToList();
        try {dict.Add(key, value);}
        catch(Exception ex) { //handle }
    }
    return dict;
