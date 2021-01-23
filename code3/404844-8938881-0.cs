    public T GetObject()
    {
        var xs = new XmlSerializer(typeof(T));
        using(var reader = xDoc.CreateReader())
        {
            return (T)xs.Deserialize(reader);
        }
    }
