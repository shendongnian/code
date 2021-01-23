        private string TextOnly(string html)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            StringBuilder innerTextBuilder = new StringBuilder();
            // filter out text nodes
            foreach (var htmlNode in doc.DocumentNode.DescendantNodes()
                                     .Where(x => x.NodeType == HtmlNodeType.Text))
            {
                innerTextBuilder.Append(htmlNode.InnerText);
            }
            innerTextBuilder.ToString();
        }
