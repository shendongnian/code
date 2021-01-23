    public static string FormatXml(string inputXml)
    {
        XmlDocument document = new XmlDocument();
        document.Load(new StringReader(inputXml));
 
        StringBuilder builder = new StringBuilder();
        using (XmlTextWriter writer = new XmlTextWriter(new StringWriter(builder)))
        {
            writer.Formatting = Formatting.Indented;
            document.Save(writer);
        }
 
        return builder.ToString();
    }
