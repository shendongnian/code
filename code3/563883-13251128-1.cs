    public IResult GetObject(XmlDocument xml)
    {
        var mySerializer = new XmlSerializer(resultType);
        using (var myStream = new MemoryStream())
        {
            xml.Save(myStream);
            myStream.Position = 0;
            return (IResult)mySerializer.Deserialize(myStream);
        }
    }
