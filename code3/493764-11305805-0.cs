    public static Object XMLStringToObject(string xml, Type objectType)
    {
        object obj = null;
        XmlSerializer ser = null;
        StringReader stringReader = null;
        XmlTextReader xmlReader = null;
        try
        {
            ser = new XmlSerializer(objectType);
            stringReader = new StringReader(xml);
            xmlReader = new XmlTextReader(stringReader);
            obj = ser.Deserialize(xmlReader);
        }
        catch
        {
            //Do nothing for now
        }
        finally
        {
            xmlReader.Close();
            stringReader.Close();
        }
        return obj;
    }
