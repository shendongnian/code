    var doc = new HtmlDocument();
    doc.LoadHtml(HTML);
    foreach (HtmlNode table in doc.DocumentNode.SelectNodes("//table"))
    {
    	foreach (HtmlNode row in table.SelectNodes("//tr"))
    	{
    		foreach (HtmlNode cell in row.SelectNodes("th|td"))
    		{
    			//don't use .ChildNodes[1] in real code, only works for <th>.
    			Debug.WriteLine(cell.ChildNodes[1].InnerHtml); 
    		}
    	}
    }
