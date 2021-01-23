    public void Save(string fileName, SaveOptions options)
    {
        XmlWriterSettings xmlWriterSettings = XNode.GetXmlWriterSettings(options);
        if ((declaration != null) && !string.IsNullOrEmpty(declaration.Encoding))
        {
            try
            {
                xmlWriterSettings.Encoding = 
                   Encoding.GetEncoding(declaration.Encoding);
            }
            catch (ArgumentException)
            {
            }
        }
    
        using (XmlWriter writer = XmlWriter.Create(fileName, xmlWriterSettings))    
            Save(writer);        
    }
