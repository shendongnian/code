                XmlDocument d = new XmlDocument();
                d.Load("c:/a.xml");
                
                XmlNode root = d.FirstChild;
                if(root.HasChildNodes)
                {
                    using(XmlWriter writer = new XmlTextWriter("c:/a.xml", Encoding.Default))
                    {
                        writer.WriteStartDocument();
                        writer.WriteStartElement(root.Name);
                        foreach(XmlNode node in root.ChildNodes)
                        {
                            writer.WriteStartElement(node.Name);
                            writer.WriteValue(node.InnerText);
                            writer.WriteEndElement();
    
                            // writing new node after "name" node
                            if (node.Name == "loop")
                            {
                                writer.WriteStartElement("name");
                                writer.WriteValue("test1");
                                writer.WriteEndElement();
                            }
    
                        }
                        writer.WriteEndElement();
                        writer.WriteEndDocument();
                    }
                }
