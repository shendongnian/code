     HtmlDocument htmlDocument = new HtmlDocument();
     htmlDocument.LoadHtml(<WEBSITEURL>);
     List<string> onlineUsers = new List<string>();
     
    foreach (HtmlNode selectNode in htmlDocument.DocumentNode.SelectNodes("//li/a[@class='username']")) {
        onlineUsers.Add(selectNode.InnerText);
                }
            }
