      HtmlNodeCollection nodes = dokuman.DocumentNode.SelectNodes("//div[@class='search_hit']//span[@prop]");
        
                for (int i = 0; i < nodes .Count; i++)
            {
                var record = new Record();
               
                    record.Name = links[i].InnerText;   results.Add(record);  }
