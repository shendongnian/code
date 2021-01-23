    /// <summary>
    /// Deserialize string XML to the object of type T.
    /// </summary>
    /// <typeparam name="T">The type of the object where the xmlText are deserialized.</typeparam>
    /// <param name="xmlText">The xml string to be deserialized to the object of type T.</param>
    public static T DeserializeXMLToObject<T>(string xmlText)
    {
        if (string.IsNullOrEmpty(xmlText)) return default(T);
        XmlSerializer xs = new XmlSerializer(typeof(T));
        using (MemoryStream memoryStream = new MemoryStream(new UnicodeEncoding().GetBytes(xmlText)))
        using (XmlTextReader xsText = new XmlTextReader(memoryStream))
        {
            xsText.Normalization = true;
            return (T)xs.Deserialize(xsText);
        }
    }
