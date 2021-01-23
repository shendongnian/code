    private static XmlDocument loadConfigDocument()
    {
        XmlDocument doc = null;
        try
        {
            doc = new XmlDocument();
            doc.Load(getConfigFilePath());
            return doc;
        }
        catch (System.IO.FileNotFoundException e)
        {
            throw new Exception("No configuration file found.", e);
        }
    }
    
    private static string getConfigFilePath()
    {
        return Assembly.GetExecutingAssembly().Location + ".config";
    }
