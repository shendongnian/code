        public static List<System.Xml.XmlNode> toList(System.Xml.XmlNodeList nodelist){
            List<System.Xml.XmlNode> nodes =  new List<System.Xml.XmlNode>();
            foreach (System.Xml.XmlNode node in nodelist)
            {
                nodes.Add(node);
            }
            return nodes;
        }
        public static ReadMeObject setXml(ReadMeObject readmeObject){
            readmeObject.xmlDocument = new System.Xml.XmlDocument();
            readmeObject.xmlDocument.LoadXml("<body>"+readmeObject.htmlStringContent+"</body>");
            System.Xml.XmlNodeList images =  readmeObject.xmlDocument.SelectNodes("//img");
            Array.ForEach(
                Functions.toList( images )
                    .Where((image) => image.Attributes != null)
                    .Where((image) => image.Attributes["src"] != null)
                    .Where((image) => image.Attributes["src"].Value != "")
                    .ToArray()                
                , (image) => {
                    Console.WriteLine(image.Attributes["src"].Value);
                }
            );
            return readmeObject;
        }
