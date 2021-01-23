     HtmlDocument doc = new HtmlDocument();
     doc.Load(yourHtml);
     foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//div[@class = 'labels']"))
     {
         Console.WriteLine(node.NextSibling.InnerText.Trim());
     }
