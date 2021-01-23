    private static string ReadInnerXML(XElement parent)
    {
        var reader = parent.CreateReader();
        reader.MoveToContent();
        var innerText = reader.ReadInnerXml();
        innerText = Regex.Replace(innerText, "<.+?>", " ");
        return innerText;
    }
