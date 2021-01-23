    string html = string.Empty;
                int tries = 5;
                while (tries > 0)
                {
                    using (var client = new WebClient())
                    {
    
                        string url = "http://google.com/";
                        client.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.8.0.4) Gecko/20060508 Firefox/1.5.0.4");
                        try
                        {
                           html = client.DownloadString(url);
                            tries--;
                            if (!string.IsNullOrEmpty(html))
                            {
                                break;
                            }
                        }
                        catch (WebException)
                        {
                            tries--;
                        }
                    }
                }
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);
