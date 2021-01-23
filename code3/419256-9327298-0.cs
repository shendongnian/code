        private static void Main(string[] args)
        {
            CreateXMlFile("c:\\test.xml", "testName", "testCompany");
        }
        private static void CreateXMlFile(string Filename, string Name, string Company)
        {
            XmlDocument doc = new XmlDocument();
            XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(docNode);
            XmlNode licenseNode = doc.CreateElement("license");
            doc.AppendChild(licenseNode);
            XmlNode node = doc.CreateElement("Name");
            node.AppendChild(doc.CreateTextNode(Name));
            licenseNode.AppendChild(node);
            node = doc.CreateElement("Company");
            node.AppendChild(doc.CreateTextNode(Company));
            licenseNode.AppendChild(node);
            StreamWriter outStream = System.IO.File.CreateText(Filename);
            doc.Save(outStream);
            outStream.Close();
        }
