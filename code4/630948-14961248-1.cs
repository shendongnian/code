            foreach (XmlNode element in xmlDocument.GetElementsByTagName("Identity"))
            {
                string output = element.Attributes[0].Value;
                foreach (XmlNode xmlNode in element.ChildNodes)
                {
                    foreach (XmlNode reference in xmlNode.ChildNodes)
                    {
                        output += reference.InnerText;
                    }
                }
                //Output here should be onelined.. 
            }
