    public static string ObjectToXMLString(Object anyObject)
    {
        string XmlizedString = string.Empty;
        XmlSerializer xs = null;
        XmlTextWriter xmlTextWriter = null;
        MemoryStream memoryStream = new MemoryStream();
        try
        {
            xs = new XmlSerializer(anyObject.GetType());
            xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.Unicode);
            xs.Serialize(xmlTextWriter, anyObject);
            memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
            XmlizedString = Encoding.Unicode.GetString(memoryStream.ToArray());
        }
        catch 
        {
            //Do nothing for now
        }
        finally
        {
            xmlTextWriter.Close();
            memoryStream.Close();
        }
        return XmlizedString;
    }
