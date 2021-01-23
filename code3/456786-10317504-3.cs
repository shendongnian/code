        public string RemoveAllAttributesFromEveryNode(string html)
        {
            var htmlDocument = new HtmlAgilityPack.HtmlDocument();
            htmlDocument.LoadHtml(html);
            foreach (var eachNode in htmlDocument.DocumentNode.SelectNodes("//*"))
                eachNode.Attributes.RemoveAll();
            html = htmlDocument.DocumentNode.OuterHtml;
            return html;
        }
