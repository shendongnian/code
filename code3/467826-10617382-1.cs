       private List<string> getLinks(HtmlAgilityPack.HtmlDocument document)
            {
               List<string> mainLinks = new List<string>();
               var linkNodes = document.DocumentNode.SelectNodes("//a[@href]");
               if (linkNodes != null)
                {
                    foreach (HtmlNode link in linkNodes)
                    {
                        var href = link.Attributes["href"].Value;
                        mainLinks.Add(href);
                    }
                }
                return mainLinks;
            }
