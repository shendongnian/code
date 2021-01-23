            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load("http://www.google.com/finance?q=NASDAQ:TXN&fstype=ii");
            // How get a specific line:
            // 1) recursively get all DIV elements with the 'id' attribute set to 'casannualdiv'
            // 2) get all TABLE elements under, with the 'id' attribute set to 'fs-table'
            // 3) recursively get all TD elements containing the given text (trimmed)
            foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//div[@id='casannualdiv']/table[@id='fs-table']//td[normalize-space(text()) = 'Deferred Taxes']"))
            {
                Console.WriteLine("Title:" + node.InnerHtml.Trim());
                // get all following sibling TD elements
                foreach (HtmlNode sibling in node.SelectNodes("following-sibling::td"))
                {
                    Console.WriteLine(" data:" + sibling.InnerText.Trim()); // InnerText works also for negative values
                }
            }
            // How to get all lines:
            // 1) recursively get all DIV elements with the 'id' attribute set to 'casannualdiv'
            // 2) get all TABLE elements under, with the 'id' attribute set to 'fs-table'
            // 3) recursively get all TD elements containing the class 'lft lm'
            foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//div[@id='casannualdiv']/table[@id='fs-table']//td[@class='lft lm']"))
            {
                Console.WriteLine("Title:" + node.InnerHtml.Trim());
                foreach (HtmlNode sibling in node.SelectNodes("following-sibling::td"))
                {
                    Console.WriteLine(" data:" + sibling.InnerText.Trim());
                }
            }
