            public static XmlDocument ObjetoToXML(object obj, XmlDocument xmlDocument, XmlNode rootNode)
        {
            if (xmlDocument == null)
                xmlDocument = new XmlDocument();
            if (obj == null) return xmlDocument;
            Type type = obj.GetType();
            if (rootNode == null) { 
                rootNode = xmlDocument.CreateElement(string.Empty, type.Name, string.Empty);
                xmlDocument.AppendChild(rootNode);
            }
            if (type.IsPrimitive || type == typeof(Decimal) || type == typeof(String) || type == typeof(DateTime))
            {
                // Simples types
                if (obj != null)
                    rootNode.InnerText = obj.ToString();
            }
            else if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>))
            {
                // Genericis types
                XmlNode node = null;
                foreach (var item in (IEnumerable)obj)
                {
                    if (node == null)
                    {
                        node = xmlDocument.CreateElement(string.Empty, item.GetType().Name, string.Empty);
                        node = rootNode.AppendChild(node);
                    }
                    ObjetoToXML(item, xmlDocument, node);
                }
            }
            else
            {
                // Classes types
                foreach (var propertie in obj.GetType().GetProperties())
                {
                    XmlNode node = xmlDocument.CreateElement(string.Empty, propertie.Name, string.Empty);
                    node = rootNode.AppendChild(node);
                    var valor = propertie.GetValue(obj, null);
                    ObjetoToXML(valor, xmlDocument, node);
                }
            }
            return xmlDocument;
        }
