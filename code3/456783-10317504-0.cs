        public string RemoveAllAttributesFromEveryNode(string html)
        {
            var document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(html);
            foreach (var eachNode in this.HtmlDocument.DocumentNode.SelectNodes("//*"))
                eachNode.Attributes.RemoveAll();
            html = document.DocumentNode.OuterHtml;
            return html;
        }
