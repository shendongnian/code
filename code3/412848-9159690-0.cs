    string StripHTML(string htmlStr)
    {
    	HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    	doc.LoadHtml(htmlStr);
    	var root = doc.DocumentNode;
    	string s = "";
    	foreach (var node in root.DescendantNodesAndSelf())
    	{
    		if (!node.HasChildNodes)
        	{
            	string text = node.InnerText;
            	if (!string.IsNullOrEmpty(text))
            	s += text.Trim() + " ";        				
    		}
    	}
    	return s.Trim();
    }
