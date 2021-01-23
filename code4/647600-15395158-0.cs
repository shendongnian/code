        public static void Main()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("XMLFile1.xml");
            XmlNodeList xNodeList = xDoc.SelectNodes("//vrttch");
            if (xNodeList.Count != 0)
            {
                xNodeList[0].Attributes["version"].Value = "Whateva";
            }
            xDoc.Save("XMLFile1.xml");
        }
