    using System.Text.RegularExpressions;
    using System.IO;
    
    static class Program
    {
        static void main()
        {
            XsdFile file = new XsdFile(@"c:\temp\test.xsd");
            Console.WriteLine(file.Query("Setup_Type"));
        }
    }
    public class XsdFile
    {
        Dictionary<string, XsdType> types;
        public XsdFile(string path)
        {
            string xsdBody = File.ReadAllText(path);
            types = XsdType.CreateTypes(xsdBody);
        }
        public string Query(string typename) {
            return Query(typename, "");
        }
        private string Query(string typename, string parent)
        {
            XsdType type;
            if (types.TryGetValue(typename, out type))
            {
                if (type.GetType() == typeof(ComplexType))
                {
                    StringBuilder sb = new StringBuilder();
                    ComplexType complexType = (ComplexType)type;
                    foreach (string elementName in complexType.elements.Keys)
                    {
                        string elementType = complexType.elements[elementName];
                        sb.AppendLine(Query(elementType, parent + "/" + elementName));
                    }
                    return sb.ToString();
                }
                else if (type.GetType() == typeof(SimpleType))
                {
                    SimpleType simpleType = (SimpleType)type;
                    return string.Format("{0} = {1}", parent, simpleType.maxLength);
                }
                else {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }
    }
    public abstract class XsdType
    {
        string name;
        public XsdType(string name)
        {
            this.name = name;
        }
        public static Dictionary<string, XsdType> CreateTypes(string xsdBody)
        {
            Dictionary<string, XsdType> types = new Dictionary<string, XsdType>();
            MatchCollection mc_types = Regex.Matches(xsdBody, @"<xsd:(?<kind>complex|simple)Type[\s\t]+(?<attributes>[^>]+)>(?<body>.+?)</xsd:\1Type>", RegexOptions.Singleline);
            foreach (Match m_type in mc_types)
            {
                string typeKind = m_type.Groups["kind"].Value;
                string typeAttributes = m_type.Groups["attributes"].Value;
                string typeBody = m_type.Groups["body"].Value;
                string typeName;
                Match m_nameattribute = Regex.Match(typeAttributes, @"name[\s\t]*=[\s\t]*""(?<name>[^""]+)""", RegexOptions.Singleline);
                if (m_nameattribute.Success)
                {
                    typeName = m_nameattribute.Groups["name"].Value;
                    if (typeKind == "complex")
                    {
                        ComplexType current_type = new ComplexType(typeName);
                        MatchCollection mc_elements = Regex.Matches(typeBody, @"<xsd:element(?<attributes>.+?)/>", RegexOptions.Singleline);
                        foreach (Match m_element in mc_elements)
                        {
                            Dictionary<string, string> elementAttributes = ParseAttributes(m_element.Groups["attributes"].Value);
                            string elementName;
                            string elementType;
                            if (!elementAttributes.TryGetValue("name", out elementName))
                                continue;
                            if (!elementAttributes.TryGetValue("type", out elementType))
                                continue;
                            current_type.elements.Add(elementName, elementType);
                        }
                        types.Add(current_type.name, current_type);
                    }
                    else if (typeKind == "simple")
                    {
                        Match m_maxLength = Regex.Match(typeBody, @"<xsd:restriction[^>]+>.+?<xsd:maxLength.+?value=""(?<maxLength>[^""]+)""", RegexOptions.Singleline);
                        if (m_maxLength.Success)
                        {
                            string maxLength = m_maxLength.Groups["maxLength"].Value;
                            SimpleType current_type = new SimpleType(typeName);
                            current_type.maxLength = maxLength;
                            types.Add(current_type.name, current_type);
                        }
                    }
                }
                else
                {
                    continue;
                }
            }
            return types;
        }
        private static Dictionary<string, string> ParseAttributes(string value)
        {
            Dictionary<string, string> attributes = new Dictionary<string, string>();
            MatchCollection mc_attributes = Regex.Matches(value, @"(?<name>[^=\s\t]+)[\s\t]*=[\s\t]*""(?<value>[^""]+)""", RegexOptions.Singleline);
            foreach (Match m_attribute in mc_attributes)
            {
                attributes.Add(m_attribute.Groups["name"].Value, m_attribute.Groups["value"].Value);
            }
            return attributes;
        }
    }
    public class SimpleType : XsdType
    {
        public string maxLength;
        public SimpleType(string name)
            : base(name)
        {
        }
    }
    public class ComplexType : XsdType
    {
        //(name-type)
        public Dictionary<string, string> elements = new Dictionary<string,string>();
        public ComplexType(string name)
            : base(name)
        {
        }
    }
