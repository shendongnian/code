    // from Plinqo: http://www.codesmithtools.com/product/frameworks
    public static string ToXml<T>(this T item)
    {
    	var settings = new XmlWriterSettings();
    	settings.Indent = true;
    	settings.OmitXmlDeclaration = true;
    
    	var sb = new System.Text.StringBuilder();
    	using (var writer = XmlWriter.Create(sb, settings))
    	{
    		var serializer = new DataContractSerializer(typeof(T));
    		serializer.WriteObject(writer, item);
    	}
    
    	return sb.ToString();
    }
