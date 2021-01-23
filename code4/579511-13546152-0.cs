    public static string BeautifyXmlDocument(XmlDocument doc)
    {
        using (StringWriter sw = new StringWriter())
        {
            XmlWriterSettings s = new XmlWriterSettings();
            s.Indent = true;
            s.IndentChars = "  ";
            s.NewLineChars = "\r\n";
            s.NewLineHandling = NewLineHandling.Replace;
            s.Encoding = new UTF8Encoding(false);
            using (XmlWriter writer = XmlWriter.Create(sw, s))
            {
                doc.Save(writer);
            }
            return sw.ToString();
        }
    }
