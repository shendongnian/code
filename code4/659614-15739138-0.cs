    public string SerializeObject<T>(T Obj)
    {
    string strxml = string.Empty;
    using (StringWriter sw = new StringWriter())
    {
        XmlSerializer xs = new XmlSerializer(typeof(T));
        xs.Serialize(sw, Obj);
        strxml = sw.ToString();
    }
    return strxml;
    }
