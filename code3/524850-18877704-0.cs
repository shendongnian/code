            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(sfetch);
            HtmlNodeCollection page = htmlDoc.DocumentNode.SelectNodes("//table");//whatever tags your are looking for in your doc
            foreach (HtmlNode value in page)
            {
                richTxtboxFilteredHTML.Text += value.InnerText;
            }
