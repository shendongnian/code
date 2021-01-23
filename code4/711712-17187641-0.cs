        static void Main(string[] args)
        {
            XmlDocument document = GetDocument(args[1]);
            SubstituteName(document, args[0]);
            SaveDocument(document, args[1]);
        }
        private static void SaveDocument(XmlDocument document, string path)
        {
            document.Save(path);
        }
        private static void SubstituteName(XmlDocument document, string ConfigName)
        {
            string name="appname "+ConfigName;
            if (ConfigName.Equals("Config1"))
                name = "appname 1";
            if (ConfigName.Equals("Config2"))
                name = "appname 2";
            XmlNode node = document.SelectSingleNode("//App");
            node.Attributes["Title"].Value = name;
        }
        private static XmlDocument GetDocument(string path)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            return doc;
        }
