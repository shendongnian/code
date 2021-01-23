     public static void XMLNodeCheck(XmlNode xmlNode)
        {
            if (xmlNode.HasChildNodes)
            {
                foreach (XmlNode node in xmlNode)
                {
                    if (node.HasChildNodes)
                    {
                        Console.WriteLine(node.Name);
                        if (node.Attributes.Count!=0)
                        {
                            foreach (XmlAttribute att in node.Attributes)
                            {
                                Console.WriteLine("----------" + att.Name + "----------" + att.Value);
                            }
                        }
                        
                        XMLNodeCheck(node);//recursive function 
                    }
                    else
                    {
                        if (!node.Equals(XmlNodeType.Element))
                        {
                            Console.WriteLine(node.InnerText);
                        }
                    }
                }
            }
        }
