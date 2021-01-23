    HtmlDocument doc = new HtmlDocument();
    doc.LoadHtml(yourHtml);
    
            Dictionary<string, string> dict = new Dictionary<string, string>();
            //This will get all div's with class as label & class value in dictionary
            
            int cnt = 1;
            foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//div[@class='label']"))
            {
                var val = 
                      doc.DocumentNode.SelectSingleNode(
                        "//div[@class='value'][" +  cnt + "]").InnerText;
                if(!dict.ContainsKey(node.InnerText))//dictionary takes unique keys only
                {
                  dict.Add(node.InnerText, val);
                  cnt++;
                }
            } 
