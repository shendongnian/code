    public string Serialize()
    {
        var types = Items.Select(x => x.GetType()).Distinct().ToArray();
        XmlSerializer ser = new XmlSerializer(typeof(ContentContainer),types);
        StringWriter writer = new StringWriter();
        ser.Serialize(writer, this);
        return writer.ToString();
    }
