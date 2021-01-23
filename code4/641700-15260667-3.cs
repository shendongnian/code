    class Program
    {
        private static XmlDocument xmlDocument_ = new XmlDocument();
        static void Main(string[] args)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            settings.CloseInput = true;
            xmlDocument_.Load(XmlReader.Create("contents.xml", settings));
            while (true)
            {
                settings.Schemas = new XmlSchemaSet();
                settings.Schemas.Add(null, "schema.xsd");
                xmlDocument_.Validate(null);
            }
        }
    }
