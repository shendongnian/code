    public static string DecodeSpecificTags(this string content, List<string> blackListedTags)
        {
            if (string.IsNullOrEmpty(content))
            {
                return content;
            }
            blackListedTags = blackListedTags.Select(t => t.ToLowerInvariant()).ToList();
            var decodedContent = HttpUtility.HtmlDecode(content);
            var document = new HtmlDocument();
            document.LoadHtml(decodedContent);
            decodedContent = blackListedTags.Select(blackListedTag => document.DocumentNode.Descendants(blackListedTag))
                    .Aggregate(decodedContent,
                        (current1, nodes) =>
                            nodes.Select(htmlNode => htmlNode.WriteTo())
                                .Aggregate(current1,
                                    (current, nodeContent) =>
                                        current.Replace(nodeContent, HttpUtility.HtmlEncode(nodeContent))));
            return decodedContent;
        }
