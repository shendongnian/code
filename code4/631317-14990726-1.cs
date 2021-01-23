    foreach (HtmlNode row in doc.DocumentNode.SelectNodes("/html/body/table/tbody/tr/td/table[@id='table2']/tbody/tr"))
	{
		HtmlNodeCollection cells = row.SelectNodes("td");
		for (int i = 0; i < cells.Count; ++i)
		{
			if (i == 0)
			{ Response.Write("Person Name : " + cells[i].InnerText + "<br>"); }
			else {
				Response.Write("Other attributes are: " + cells[i].InnerText + "<br>"); 
			}
		}
	}
