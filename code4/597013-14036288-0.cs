    HtmlElementCollection links = webBrowser1.Document.GetElementsByTagName("table"); //get collection in link
                    {
                        foreach (HtmlElement link_data in links) //parse for each collection
                        {
                            String width = link_data.GetAttribute("width");
                            {
                                if (width != null && width == "150")
                                {
                                    Regex linkX = new Regex("<a[^>]*?href=\"(?<href>[\\s\\S]*?)\"[^>]*?>(?<Title>[\\s\\S]*?)</a>", RegexOptions.IgnoreCase);
                                    MatchCollection category_urls = linkX.Matches(link_data.OuterHtml);
                                    if (category_urls.Count > 0)
                                    {
                                        foreach (Match match in category_urls)
                                        {
                                               //rest of the code
                                        }
                                    }
                                 }
                             }
                         }
                    }
