    namespace XMLToClasses
    {
        public class Element
        {
            public string Name;
            public HashSet<string> attributes;
            public HashSet<string> children;
            public bool hasText;
            public Element()
            {
                Name = "";
                attributes = new HashSet<string>();
                children = new HashSet<string>();
                hasText = false;
            }
        public string getSource()
            {
                StringBuilder sourceSB = new StringBuilder();
                sourceSB.AppendLine("[Serializable()]");
                sourceSB.AppendLine("public class cls_" + Name);
                sourceSB.AppendLine("{");
                
                sourceSB.AppendLine("\t// Attributes" );
                if (hasText)
                {
                    sourceSB.AppendLine("\tstring InnerText;");
                }
                foreach(string attribute in attributes)
                {
                    sourceSB.AppendLine("\tpublic string atr_" + attribute + ";");
                }
                sourceSB.AppendLine("");
                sourceSB.AppendLine("\t// Children");
                foreach (string child in children)
                {
                    sourceSB.AppendLine("\tpublic List<cls_" + child + "> list" + child + ";");
                }
                sourceSB.AppendLine("");
                sourceSB.AppendLine("\t// Constructor");
                sourceSB.AppendLine("\tpublic cls_" + Name + "()");
                sourceSB.AppendLine("\t{");
                foreach (string child in children)
                {
                    sourceSB.AppendLine("\t\tlist" + child + " = new List<cls_" + child + ">()" + ";");
                }
                sourceSB.AppendLine("\t}");
                sourceSB.AppendLine("");
                sourceSB.AppendLine("\tpublic cls_" + Name + "(XmlNode xmlNode) : this ()");
                sourceSB.AppendLine("\t{");
                if (hasText)
                {
                    sourceSB.AppendLine("\t\t\tInnerText = xmlNode.InnerText;");
                    sourceSB.AppendLine("");
                }            
                foreach (string attribute in attributes)
                {
                    sourceSB.AppendLine("\t\tif (xmlNode.Attributes[\"" + attribute + "\"] != null)");
                    sourceSB.AppendLine("\t\t{");
                    sourceSB.AppendLine("\t\t\tatr_" + attribute + " = xmlNode.Attributes[\"" + attribute + "\"].Value;");
                    sourceSB.AppendLine("\t\t}");
                }
                sourceSB.AppendLine("");
                            
                foreach (string child in children)
                {
                    sourceSB.AppendLine("\t\tforeach (XmlNode childNode in xmlNode.SelectNodes(\"./" + child + "\"))");
                    sourceSB.AppendLine("\t\t{");
                    sourceSB.AppendLine("\t\t\tlist" + child + ".Add(new cls_" + child + "(childNode));");
                    sourceSB.AppendLine("\t\t}");
                }
                
                sourceSB.AppendLine("\t}");
                sourceSB.Append("}");
                return sourceSB.ToString();
            }
        }
        public class XMLToClasses
        {
            public Hashtable extantElements;
            public XMLToClasses()
            {
                extantElements = new Hashtable();
            }
            public Element processElement(XmlNode xmlNode)
            {
                Element element;
                if (extantElements.Contains(xmlNode.Name))
                {
                    element = (Element)extantElements[xmlNode.Name];
                }
                else
                {
                    element = new Element();
                    element.Name = xmlNode.Name;
                    extantElements.Add(element.Name, element);
                }            
                if (xmlNode.Attributes != null)
                {
                    foreach (XmlAttribute attribute in xmlNode.Attributes)
                    {
                        if (!element.attributes.Contains(attribute.Name))
                        {
                            element.attributes.Add(attribute.Name);
                        }
                    }
                }
                if (xmlNode.ChildNodes != null)
                {
                    foreach (XmlNode node in xmlNode.ChildNodes)
                    {
                        if (node.Name == "#text")
                        {
                            element.hasText = true;
                        }
                        else
                        {
                            Element childNode = processElement(node);
                            if (!element.children.Contains(childNode.Name))
                            {
                                element.children.Add(childNode.Name);
                            }
                        }
                    }
                }
                return element;
            }
        }
    }
