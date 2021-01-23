    public static string ToXml(object obj)
    {
    	XmlAttributeOverrides xmlOver = new XmlAttributeOverrides();
    	XmlAttributes xmlAttr = new XmlAttributes();
    	xmlAttr.XmlIgnore = true;
    	xmlOver.Add(typeof(ClassB), "ThePropertyNameToIgnore", xmlAttr);
    	
    	
    	XmlSerializer xs = new XmlSerializer(typeof(ClassA), xmlOver);
    	using (MemoryStream stream = new MemoryStream())
    	{
    		xs.Serialize(stream, obj);
    		return System.Text.Encoding.UTF8.GetString(stream.ToArray());
    	}
    }
