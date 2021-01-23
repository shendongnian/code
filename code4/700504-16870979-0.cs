	var doc = XDocument.Parse(xml);
	string[] filesAndMD5 = doc.Descendants("file")
							  .Select(node => GetFullPath(node) + ", " + node.Attribute("md5").Value)
							  .ToArray();							  
	
	filesAndMD5.ForEach(Console.WriteLine);
    public string GetFullPath(XElement node)
    {
    	string res = "";
    	
    	while(node != null)
    	{
    		res = Path.Combine(node.Attribute("name").Value, res);
    		node = node.Parent;
    	}
    	return res;
    }
