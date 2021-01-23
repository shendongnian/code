    static string GetAppath(string xmlString, string picPath)
        {
            string appath = String.Empty;
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(xmlString);
            XmlNodeList xList = xDoc.SelectNodes("/picture");
            foreach (XmlNode xNode in xList)
            {
                if (xNode["path"].InnerText == picPath)
                {
                    appath = xNode["appath"].InnerText;
                    break;
                }
            }
            return appath;
        }
