    foreach (HtmlAgilityPack.HtmlNode node in doc.DocumentNode.SelectNodes("//span[@prop]/ancestor::div[@class='search_hit']"))
       {
            Record rec = new Record();
            foreach (HtmlAgilityPack.HtmlNode node2 in node.SelectNodes(".//span[@prop]"))
               {
               }
               rList.Results.Add(rec);
       }
