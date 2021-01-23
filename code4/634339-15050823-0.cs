    public string Serialize<T>(T o)
    {
        var x = new XDocument();
        using(var w = x.CreateWriter())
            new XmlSerializer(typeof(T)).Serialize(w, o);
        return x.ToString();
    }
    
    public T Deserialize<T>(string s)
    {
        return
            (T)new XmlSerializer(typeof(T))
            .Deserialize(XDocument.Parse(s)
            .CreateReader());
    }
