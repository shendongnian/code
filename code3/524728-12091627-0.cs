    public static string GetStringAttribute(XmlNode node, string name, string defaultValue="")
        {
            XmlNode attrNode = node.Attributes.GetNamedItem(name);
            if (attrNode == null)
                return defaultValue;
            else
                return attrNode.Value.Trim();
        }
