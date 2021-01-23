    protected string FormatXml(XmlNode xmlNode)
    {        
        StringBuilder builder = new StringBuilder();
    
        // We will use stringWriter to push the formated xml into our StringBuilder bob.
        using (StringWriter stringWriter = new StringWriter(builder))
        {
            // We will use the Formatting of our xmlTextWriter to provide our indentation.
            using (XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter))
            {
                xmlTextWriter.Formatting = Formatting.Indented;
                xmlNode.WriteTo(xmlTextWriter);
            }
        }
    
        return builder.ToString();
    }
