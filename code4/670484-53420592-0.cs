    string json = obj.ToJSON();
    json = System.Text.RegularExpressions.Regex.Unescape(json);
    File.WriteAllText("<DirectoryFile>.json", json);
    public static string ToJSON(this object obj)
    {
        var serializer = new JavaScriptSerializer();
        serializer.MaxJsonLength = Int32.MaxValue;
        JavaScriptSerializer js = new JavaScriptSerializer();
        return js.Serialize(obj);
    }
        
