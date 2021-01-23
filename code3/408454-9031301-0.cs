        static string ParseNode(XmlElement e, string AttributeOrNodeName)
        {
            if (e.HasAttribute(AttributeOrNodeName))
            {
                return e.GetAttribute(AttributeOrNodeName);
            }
            var node = e[AttributeOrNodeName];
            if (node != null)
            {
                return node.InnerText;
            }
            throw new Exception("The input element doesn't have specified attribute or node.");
        }
    
