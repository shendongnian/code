    public static void Save(string x, string y, string name)
        {
            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\appName"))
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\appName");
            }
            XmlDocument xmlDocument = new XmlDocument();
            string xml = string.Format(@"<?xml version='1.0' encoding='utf-8'?><button><x>{0}</x><y>{1}</y><name>{2}</name></button>", x, y, name);
            xmlDocument.LoadXml(xml);
            xmlDocument.Save(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\appName\\button.xml");
        }
        public static Dictionary<string,string> Load()
        {
            string address = "";
            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\appName\\button.xml"))
            {
                return new Dictionary<string,string>(){{"x",""},{"y",""},{"name",""}};
            }
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\appName\\button.xml");
            XmlNode button = xmlDocument.GetElementsByTagName("button").Item(0);
            XmlNode nameNode = button.SelectSingleNode("name");
            XmlNode xNode = button.SelectSingleNode("x");
            XmlNode yNode = button.SelectSingleNode("y");
            return new Dictionary<string, string>() { { "name", nameNode.InnerText }, { "x", xNode.InnerText }, { "y", yNode.InnerText } };
        }
