        public static string Serialize<T>(T obj)
        {
            var writer = new StringWriter();
	        Serialize<T>(obj,writer);
            var xml = writer.ToString();
            return xml;
        }
    	public static void Serialize<T>(T obj, string filepath)
        {
            var writer = new StreamWriter(filepath);
	        Serialize<T>(obj,writer);
        }
    	public static void Serialize<T>(T obj, TextWriter writer)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            XmlWriter xmlWriter = XmlWriter.Create(writer, settings);            
            XmlSerializerNamespaces names = new XmlSerializerNamespaces();
            names.Add("", "");            
            XmlSerializer serializer = new XmlSerializer(typeof(T));            
            serializer.Serialize(xmlWriter, obj, names);
        }
