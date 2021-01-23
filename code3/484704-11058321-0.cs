    public static string GetSingleValue(string strXPathExpression, string strAttributeName)
            {
                XmlNode node = GetNode(strXPathExpression);
                if (node != null)
                {
                    XmlAttribute attribute = node.Attributes[strAttributeName];
                    if (attribute != null)
                        return attribute.Value;
                }
    
                return string.Empty;
               
    
            }
