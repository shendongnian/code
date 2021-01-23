    private static string ReadInnerXML(XElement parent)
    {
        var reader = parent.CreateReader();
        reader.MoveToContent();
        var innerText = reader.ReadInnerXml();
        return innerText;
    }
