     HtmlDocument htmlDocument = new HtmlDocument();
     htmlDocument.LoadHtml("http://vizor.us/forum.php");
     List<string> onlineUsers = new List<string>();
     
    foreach (HtmlNode selectNode in htmlDocument.DocumentNode.SelectNodes("//li/a[@class='username']")) {
        onlineUsers.Add(selectNode.InnerText);
                }
            }
