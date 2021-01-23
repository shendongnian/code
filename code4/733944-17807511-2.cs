    public string GetData(string comaSeparatedNames)
    {
        string[] names = comaSeparatedNames.Split(',');
        dynamic d = new ExpandoObject();
        dynamic dNames = new ExpandoObject();
        foreach (var name in names)
        {
            dynamic properties = new ExpandoObject();
            properties.url = "foo";
            properties.desc = "bar";
            ((IDictionary<string, object>)dNames).Add(name, properties);
        }
        ((IDictionary<string, object>)d).Add("userTypes", dNames);
        var s = JsonSerializer.Create();
        var sb = new StringBuilder();
        using (var sw = new StringWriter(sb))
        {
            s.Serialize(sw, d);
        }
        return sb.ToString();
    }
