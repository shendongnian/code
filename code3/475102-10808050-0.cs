    private List<HtmlNode> GetSection(HtmlDocument helpDocument, string SectionName)
    {
    	HtmlNode startNode = helpDocument.DocumentNode.Descendants("div").Where(d => d.InnerText.Equals(SectionName, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
    	if (startNode == null)
    		return null; // section not found
    
    	List<HtmlNode> section = new List<HtmlNode>();
    	HtmlNode sibling = startNode.NextSibling;
    	while (sibling != null && sibling.Descendants("h1").Count() <= 0)
    	{
    		section.Add(sibling);
    		sibling = sibling.NextSibling;
    	}
    
    	return section;
    }
