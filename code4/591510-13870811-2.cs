        private static string transformFromMergeCodesToHtml(string textWithMergeCodes)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(textWithMergeCodes);
            var nodes = doc.DocumentNode.Descendants("#text").Where(text => Regex.IsMatch(text.InnerText.Trim(), @"≤[^≥]*≥"));
            string format =
                @"<div class=""wrapper"" contenteditable=""false""><span class=""wrapper2""><div class=""myClass"">$2</div><button type="" button"" class=""MergeCodeRemoveIcon"">×</button></span></div>";
            foreach (var htmlNode in nodes)
            {
                htmlNode.InnerHtml = Regex.Replace(htmlNode.InnerText.Trim(), @"(≤)([^≥]*)(≥)", format);
            }
            return doc.DocumentNode.OuterHtml;
        }
        private static string transformFromHtmlToMergeCodes(string text)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(text);
            var nodes = doc.DocumentNode.SelectNodes("//div[@class='wrapper']");
            foreach (var item in nodes)
            {
                var innerText = "≤" + item.SelectSingleNode("//div[@class='myClass']").InnerText.Trim() + "≥";
                var textNode = HtmlNode.CreateNode(innerText);
                item.ParentNode.ReplaceChild(textNode, item);
            }
            return doc.DocumentNode.InnerHtml;
        }
