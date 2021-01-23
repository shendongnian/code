    namespace BBCode
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
                sourceSB.AppendLine("public class cls_" + Name);
                sourceSB.AppendLine("{");
                
                sourceSB.AppendLine("\t// Attributes" );
                if (hasText)
                {
                    sourceSB.AppendLine("\tstring InnerText;");
                }
                foreach(string attribute in attributes)
                {
                    sourceSB.AppendLine("\tstring atr_" + attribute + ";");
                }
                sourceSB.AppendLine("");
                sourceSB.AppendLine("\t// Children");
                foreach (string child in children)
                {
                    sourceSB.AppendLine("\tList<" + child + "> list" + child + ";");
                }
                sourceSB.AppendLine("");
                sourceSB.AppendLine("\t// Constructor");
                sourceSB.AppendLine("\tpublic " + Name + "()");
                sourceSB.AppendLine("\t{");
                foreach (string child in children)
                {
                    sourceSB.AppendLine("\t\tlist" + child + " = new List<" + child + ">()" + ";");
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
