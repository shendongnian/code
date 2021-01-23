            var xml="<Row>...</Row>"
            var xmlReader = XmlReader.Create(new StringReader(xml));
            if (xmlReader.ReadToFollowing("Row"))
            {
                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                    {
                        var name = xmlReader.Name;
                        //read value of element.
                        while (xmlReader.Read())
                        {                            
                            if (xmlReader.NodeType == XmlNodeType.Whitespace)
                                break;
                            if (xmlReader.NodeType == XmlNodeType.Text)
                            {
                                var value = xmlReader.Value;
                            }
                            else if (xmlReader.NodeType == XmlNodeType.EndElement)
                                break;
                        }
                    }
                }
            }
