     public static string Serialize<T>(this T value, string xmlDeclaration = "<?xml version=\"1.0\"?>") where T : class, new()
            {
                if (value == null) return string.Empty;
    
                using (var stringWriter = new StringWriter())
                {
                    var settings = new XmlWriterSettings
                    {
                        Indent = true,
                        OmitXmlDeclaration = xmlDeclaration != null,
                    };
    
                    using (var xmlWriter = XmlWriter.Create(stringWriter, settings))
                    {
                        var xmlSerializer = new XmlSerializer(typeof(T));
    
                        xmlSerializer.Serialize(xmlWriter, value);
    
                        var sb = new StringBuilder($"{Environment.NewLine}{stringWriter}");
    
                        sb.Insert(0, xmlDeclaration);
    
                        return sb.ToString();
                    }
                }
