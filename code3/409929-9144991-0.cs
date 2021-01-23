          string page;
          using(WebClient client = new WebClient())
          {
              page = client.DownloadString(url);
          }
          HtmlDocument doc = new HtmlDocument();  
          doc.LoadHtml(page);
                
          string result;
          HtmlNode node = doc.DocumentNode.SelectSingleNode("//span[@class='obf']");
          result = node.InnerText;
         
                
