    void Main()
    {
    	string htmlPath = @"C:\Users\Jschubert\Desktop\html\test.html";
    	var sgmlReader = new Sgml.SgmlReader();
    	var stringReader = new StringReader(File.ReadAllText(htmlPath));
    	
    	sgmlReader.DocType = "HTML";
    	sgmlReader.WhitespaceHandling = WhitespaceHandling.All;
    	sgmlReader.CaseFolding = Sgml.CaseFolding.ToLower;
    	sgmlReader.InputStream = stringReader;
    
    	// create document
    	var doc = new XmlDocument();
    	doc.PreserveWhitespace = true;
    	doc.XmlResolver = null;
    	doc.Load(sgmlReader);
    	
    	List<XmlNode> nodes = doc.GetElementsByTagName("script")
                              .Cast<XmlNode>().ToList();
    	var byType = doc.SelectNodes("script[@type = 'text/javascript']")
                              .Cast<XmlNode>().ToList();
    	var style = doc.GetElementsByTagName("style").Cast<XmlNode>().ToList();
    	nodes.AddRange(byType);
    	nodes.AddRange(style);
    	
    	for (int i = nodes.Count - 1; i >= 0; i--)
    	{
    		nodes[i].ParentNode.RemoveChild(nodes[i]);
    	}
    	
    	doc.DumpFormatted();
    	
    	stringReader.Close();
    	sgmlReader.Close();
    }
