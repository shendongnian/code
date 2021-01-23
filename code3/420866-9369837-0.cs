    public static string ExtractTextFromHtml(this string text)
            {
                if (String.IsNullOrEmpty(text))
                    return text;
                var sb = new StringBuilder();
                var doc = new HtmlDocument();
                doc.LoadHtml(text);
                foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//text()"))
                {
                    if (!String.IsNullOrWhiteSpace(node.InnerText))
                        sb.Append(HtmlEntity.DeEntitize(node.InnerText.Trim()) + " ");
                }
                return sb.ToString();
            }
