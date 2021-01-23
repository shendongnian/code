    //find the li -- a *little* complicated with nested Where clauses, but clear enough.
    HtmlNode li = htmlDoc.DocumentNode.Descendants("li").Where(n => n.ChildNodes.Where(a => a.Name.Equals("a") && a.Id.Equals("menuItem2", StringComparison.InvariantCultureIgnoreCase)).Count() > 0).FirstOrDefault();
    IEnumerable<HtmlNode> liNodes = null;
    if (li != null)
    {
    	//Node found, get all the descendent <li>
    	liNodes = li.Descendants("li");
    }
