    HtmlNodeCollection OneHome = document.DocumentNode.SelectNodes("//div[@id='accordion1']");
        var OneHomelinks = OneHome.Descendants("a")
                .Select(a => a.OuterHtml)
                .ToList();
		var headerCount = 0;
        foreach (string link in OneHomelinks)
        {
			var prevCounter = headerCount;
            if (link.Contains('#'))
            {
				headerCount++;
				
				if (headerCount != 1 && headerCount > prevCounter) {
					Response.Write("</ul>");
					Response.Write("</p>");
					Response.Write("</div>");
				}
				
                Response.Write("<div data-role=\"collapsible\" data-collapsed=\"true\">");
                Response.Write("<h3>" + link + "</h3>");
                Response.Write("<p>");
                Response.Write("<ul>");
				
            }
			else {
                Response.Write("<li>" + link + "</li>");
            } 
        }
		Response.Write("</ul>");
		Response.Write("</p>");
		Response.Write("</div>");
