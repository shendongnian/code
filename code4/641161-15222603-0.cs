    private T ParseNode<T>(XmlDocument doc, string node, T defaultValue)
    {
        try
        {
            XmlNode xmlNode = doc.SelectSingleNode(node);
            if (xmlNode == null)
                return defaultValue;
            string text = xmlNode.InnerText;
            return SafeConvert(text, defaultValue);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return defaultValue;
    }
    public static T SafeConvert<T>(string s, T defaultValue)
    {
    	if ( string.IsNullOrEmpty(s) )
    		return defaultValue;
    	return (T)Convert.ChangeType(s, typeof(T));
    }
