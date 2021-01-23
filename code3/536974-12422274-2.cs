    private static String SerializeObject<T>(T myObj, bool format) {
        try {
            String xmlizedString = null;
            MemoryStream memoryStream = new MemoryStream();
            XmlSerializer xs = null;
            XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
            if (format)
                xmlTextWriter.Formatting = Formatting.Indented;
        
            xs = new XmlSerializer(typeof(T), "MyXmlData");
        
            xs.Serialize(xmlTextWriter, myObj);
        
            memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
            //eventually
            xmlizedString = UTF8ByteArrayToString(memoryStream.ToArray());
            return xmlizedString;
        } 
        catch (Exception e) {
            //return e.ToString();
            throw;
        }
    }
