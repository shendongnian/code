    HtmlAgilityPack.HtmlDocument htmlContent = new HtmlAgilityPack.HtmlDocument();
            htmlContent.LoadHtml(htmlCode);
            if (htmlContent.DocumentNode != null)
            {
                foreach (HtmlNode n in htmlContent.DocumentNode.Descendants("div"))
                {
                    if (n.HasAttributes && n.Attributes["class"] != null)
                    {
                        if (n.Attributes["class"].Value == "className")
                        {
                          // Do something
                        } 
                    }                 
                }
            }
