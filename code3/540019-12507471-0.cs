    private const string XML_FILE_NAME = "sample.xml";
    public static XmlDocument LoadSampleXML()
        {
            XmlDocument oXmlDocument = null;
            try
            {
                oXmlDocument= new XmlDocument();
                oXmlDocument.Load(XML_FILE_NAME);
                return oXmlDocument;
            }
            catch (Exception ex)
            {
                return oXmlDocument;
            }
        }
