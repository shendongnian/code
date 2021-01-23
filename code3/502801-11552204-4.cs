    public static XElement GetXElementFromLitePageData(LitePageData objectToSerialize)
    {
        var xmlSerializer = new XmlSerializer(typeof(LitePageData));
        var doc = new XDocument();
        using (XmlWriter xmlWriter = doc.CreateWriter())
        {
            xmlSerializer.Serialize(xmlWriter, objectToSerialize);
        }
        return doc.Root;
    }
