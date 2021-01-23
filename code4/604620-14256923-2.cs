    public IEnumerable<XElement> doSearch(string strSearchContent)
    {
    	string fileName = HttpContext.Current.Server.MapPath(@"~\XMLFiles/Mobile.xml");
    
        if (File.Exists(fileName))
        {
            XDocument doc = XDocument.Load(fileName);
    		return doc.XPathSelectElements("//MDetails")
                      .Where(node => node.Attribute("Desc").Value.Contains(strSearchContent));
        }
    	
    	return Enumerable.Empty<XElement>();
    }
