    namespace Utility1 
    {
    public static class XMLHelper
    {
       private enum XMLType
       {
          Element,
          Attribute
       }
        public static string GenerateXMLClass(string xmlstring)
        {
            XmlDocument xd = new XmlDocument();
            xd.LoadXml(xmlstring);
            XmlNode rootNode = xd.DocumentElement;
            var xmlClassCollection = new Dictionary<string, XMLClass>();
            var xmlClass = new XMLClass();
            xmlClassCollection.Add(rootNode.Name, xmlClass);
            CollectAttributes(ref xmlClass, rootNode);
            CollectElements(ref xmlClass, rootNode);
            CollectChildClass(ref xmlClassCollection, rootNode);
            var clsBuilder = new StringBuilder();
            clsBuilder.AppendLine("[XmlRoot(\"" + rootNode.Name + "\")]");
            foreach (var cls in xmlClassCollection)
            {
                clsBuilder.AppendLine("public class " + cls.Key);
                clsBuilder.AppendLine("{");
                foreach (var element in cls.Value.Elements)
                {
                    if (XMLType.Element == element.XmlType)
                        clsBuilder.AppendLine("[XmlElement(\"" + element.Name + "\")]");
                    else
                        clsBuilder.AppendLine("[XmlAttribute(\"" + element.Name + "\")]");
                    clsBuilder.AppendLine("public " + element.Type + element.Name + "{get;set;}");
                }
                clsBuilder.AppendLine("}");
            }
            return clsBuilder.ToString();
        }
        private static void CollectAttributes(ref XMLClass xmlClass, XmlNode node)
        {
            if (null != node.Attributes)
            {
                foreach (XmlAttribute attr in node.Attributes)
                {
                    if (null == xmlClass.Elements.SingleOrDefault(o => o.Name == attr.Name))
                        xmlClass.Elements.Add(new Element("string ", attr.Name, XMLType.Attribute));
                }
            }
        }
        private static bool IsEndElement(XmlNode node)
        {
            if ((null == node.Attributes || node.Attributes.Count <= 0) &&
                       (null == node.ChildNodes || !node.HasChildNodes || (node.ChildNodes.Count == 1 && node.ChildNodes[0].NodeType == XmlNodeType.Text)))
            {
                return true;
            }
            return false;
        }
        private static void CollectElements(ref XMLClass xmlClass, XmlNode node)
        {
            foreach (XmlNode childNode in node.ChildNodes)
            {
                if (null == xmlClass.Elements.SingleOrDefault(o => o.Name == childNode.Name))
                {
                    var occurance = node.ChildNodes.Cast<XmlNode>().Where(o => o.Name == childNode.Name).Count();
                    var appender = "  ";
                    if (occurance > 1)
                        appender = "[] ";
                   if(IsEndElement(childNode))
                    {
                        xmlClass.Elements.Add(new Element("string" + appender, childNode.Name, XMLType.Element));
                    }
                    else
                    {
                        xmlClass.Elements.Add(new Element(childNode.Name + appender, childNode.Name, XMLType.Element));
                    }
                }
            }
        }
        private static void CollectChildClass(ref Dictionary<string, XMLClass> xmlClsCollection, XmlNode node)
        {
            foreach (XmlNode childNode in node.ChildNodes)
            {
                if (!IsEndElement(childNode))
                {
                    XMLClass xmlClass;
                    if (xmlClsCollection.ContainsKey(childNode.Name))
                        xmlClass = xmlClsCollection[childNode.Name];
                    else
                    {
                        xmlClass = new XMLClass();
                        xmlClsCollection.Add(childNode.Name, xmlClass);
                    }
                    CollectAttributes(ref xmlClass, childNode);
                    CollectElements(ref xmlClass, childNode);
                    CollectChildClass(ref xmlClsCollection, childNode);
                }
            }
        }
        private class XMLClass
        {
            public XMLClass()
            {
                Elements = new List<Element>();
            }
            public List<Element> Elements { get; set; }
        }
        
        private class Element
        {
            public Element(string type, string name, XMLType xmltype)
            {
                Type = type;
                Name = name;
                XmlType = xmltype;
            }
            public XMLType XmlType { get; set; }
            public string Name { get; set; }
            public string Type { get; set; }
        }
      }
    }
     
