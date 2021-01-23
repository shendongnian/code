     public class Whatever
        {
            public int SkuNumber { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
        [WebMethod]
        public void HelloWorld(string xmlString)
        {
            //make all the node names + attribute names lowercase, to account for erroneous xml formatting -- leave the values alone though
            xmlString = Regex.Replace(xmlString, @"<[^<>]+>", m => m.Value.ToLower(),RegexOptions.Multiline | RegexOptions.Singleline);
            var xmlDoc = LoadXmlDocument(xmlString);
            
            
            var listOfStuff = new List<Whatever>();
            var rootNode = xmlDoc.DocumentElement;
            foreach(XmlNode xmlNode in rootNode)
            {
                var whatever = new Whatever
                                   {
                                       FirstName = xmlNode["first_name"].InnerText,
                                       LastName = xmlNode["last_name"].InnerText,
                                       SkuNumber = Convert.ToInt32(xmlNode["sku_number"].InnerText)
                                   };
                listOfStuff.Add(whatever);
            }
        }
        public static XmlDocument LoadXmlDocument(string xmlString)
        {
            //some extra stuff to account for URLEncoded strings, if necessary
            if (xmlString.IndexOf("%3e%") > -1)
                xmlString = HttpUtility.UrlDecode(xmlString);
            xmlString = xmlString.Replace((char)34, '\'').Replace("&", "&amp;").Replace("\\", "");
            var xmlDocument = new XmlDocument();
            xmlDocument.PreserveWhitespace = false;
            xmlDocument.LoadXml(xmlString);
            return xmlDocument;
        }
