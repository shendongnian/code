        private List<string> getLinks(HtmlAgilityPack.HtmlDocument document)
            {
               List<string> mainLinks = new List<string>();
               if (document.DocumentNode.SelectNodes("//a[@href]") != null)
                {
                    foreach (HtmlNode link in document.DocumentNode.SelectNodes("//a[@href]"))
                    {
                        var href = link.Attributes["href"].Value;
                        mainLinks.Add(href);
                    }
                }
                return mainLinks;
            }
