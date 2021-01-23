            string path = @"..\LinqToXml\LinqToXml\config.Xml";
           
            XElement doc2 = XElement.Load(path);
            var element = from t in doc2.Descendants() select t;
            foreach (var el in element)
            {
                if (el.HasAttributes)
                {
                    foreach (var att in el.Attributes())
                    {
                        Debug.WriteLine(att.Value);
                    }
                }
            }
            
