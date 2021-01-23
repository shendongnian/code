    private static T ParseNode<T>(XmlDocument doc, string node, object defaultValue)
    {
        object ret = defaultValue;
        try
        {
            
            XmlNode xmlNode = doc.SelectSingleNode(node);
            if (xmlNode == null)
                return default(T);
            string text = xmlNode.InnerText;
            if (defaultValue is int)
                ret = int.Parse(text);
            if (defaultValue is bool)
                ret =  bool.Parse(text);
            if (defaultValue is string)
                ret = text;
            if (defaultValue is DateTime)
                ret = DateTime.Parse(text);
            return (T) ret;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return (T)ret;
    }
