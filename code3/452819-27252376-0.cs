      public static string Serialize<T>(T obj)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            var writer = new StringWriter();
            XmlWriter xmlWriter = XmlWriter.Create(writer, settings);
            
            XmlSerializerNamespaces names = new XmlSerializerNamespaces();
            names.Add("", "");
            
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            
            serializer.Serialize(xmlWriter, obj, names);
            var xml = writer.ToString();
            return xml;
        }
    public static void Serialize<T>(T obj, string filepath)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            var writer = new StreamWriter(filepath);
            XmlWriter xmlWriter = XmlWriter.Create(writer, settings);
            
            XmlSerializerNamespaces names = new XmlSerializerNamespaces();
            names.Add("", "");
            
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            
            serializer.Serialize(xmlWriter, obj, names);
        }
