    public class HtmlSanitizer
    {
        private readonly IDictionary<string, string[]> _whitelist;
        private readonly List<string> _deletableNodesXpath = new List<string>();
        public HtmlSanitizer()
        {
            _whitelist = new Dictionary<string, string[]>
                            {
                                {"a", new[] {"href", "target", "title"}},
                                {"img", new[] {"src", "alt", "width", "height"}},
                                {"iframe", new[] {"src", "width", "height", "frameborder", "allowfullscreen" }},
                                {"strong", null},
                                {"em", null},
                                {"blockquote", null},
                                {"b", null},
                                {"p", null},
                                {"ul", null},
                                {"ol", null},
                                {"li", null},
                                {"div", new[] {"align"}},
                                {"strike", null},
                                {"u", null},
                                {"sub", null},
                                {"sup", null},
                                {"table", null},
                                {"tr", null},
                                {"td", null},
                                {"th", null},
                                {"dd", null},
                                {"dt", null},
                                {"dl", null},
                                {"h1", null},
                                {"h2", null},
                                {"h3", null},
                            };
        }
        public string Sanitize(string input)
        {
            if (input.Trim().Length < 1)
                return string.Empty;
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(input);
            SanitizeNode(htmlDocument.DocumentNode);
            string xPath = CreateXPath();
            return StripHtml(htmlDocument.DocumentNode.WriteTo().Trim(), xPath);
        }
        private void SanitizeChildren(HtmlNode parentNode)
        {
            for (int i = parentNode.ChildNodes.Count - 1; i >= 0; i--)
            {
                SanitizeNode(parentNode.ChildNodes[i]);
            }
        }
        private static Regex _srcAttribute = new Regex(@"^https?://[-a-z0-9+&@#/%?=~_|!:,.;\(\)]+$", RegexOptions.Singleline | RegexOptions.IgnoreCase
                             | RegexOptions.ExplicitCapture | RegexOptions.Compiled | RegexOptions.IgnorePatternWhitespace);
        private static Regex _iframeSrc = new Regex(@"https?://(player.vimeo.com|www.youtube.com)/[-a-z0-9+&@#/%?=~_|!:,.;\(\)|\s]+", RegexOptions.Singleline | RegexOptions.IgnoreCase
                             | RegexOptions.ExplicitCapture | RegexOptions.Compiled | RegexOptions.IgnorePatternWhitespace);
                
        private void SanitizeNode(HtmlNode node)
        {
            if (node.NodeType == HtmlNodeType.Element)
            {
                if (!_whitelist.ContainsKey(node.Name))
                {
                    if (!_deletableNodesXpath.Contains(node.Name))
                    {
                        //DeletableNodesXpath.Add(node.Name.Replace("?",""));
                        node.Name = "removeableNode";
                        _deletableNodesXpath.Add(node.Name);
                    }
                    if (node.HasChildNodes)
                    {
                        SanitizeChildren(node);
                    }
                    return;
                }
                if (node.HasAttributes)
                {
                    for (int i = node.Attributes.Count - 1; i >= 0; i--)
                    {
                        HtmlAttribute currentAttribute = node.Attributes[i];
                        string[] allowedAttributes = _whitelist[node.Name];
                        if (allowedAttributes != null)
                        {
                            if (!allowedAttributes.Contains(currentAttribute.Name))
                            {
                                node.Attributes.Remove(currentAttribute);
                            }
                            // if img src ensure matches regex 
                            if (node.Name == "img" && currentAttribute.Name == "src")
                            {
                                if (!_srcAttribute.IsMatch(currentAttribute.Value))
                                {
                                    // remove node 
                                    node.Name = "removeableNode";
                                    _deletableNodesXpath.Add(node.Name);
                                }
                            }
                            // if iframe - ensure it within allowed src tags 
                            if (node.Name == "iframe" && currentAttribute.Name == "src")
                            {
                                if (!_iframeSrc.IsMatch(currentAttribute.Value))
                                {
                                    // remove node 
                                    node.Name = "removeableNode";
                                    _deletableNodesXpath.Add(node.Name);
                                }
                            }
                        }
                        else
                        {
                            node.Attributes.Remove(currentAttribute);
                        }
                    }
                }
            }
            if (node.HasChildNodes)
            {
                SanitizeChildren(node);
            }
        }
        private string StripHtml(string html, string xPath)
        {
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            if (xPath.Length > 0)
            {
                HtmlNodeCollection invalidNodes = htmlDoc.DocumentNode.SelectNodes(@xPath);
                foreach (HtmlNode node in invalidNodes)
                {
                    node.ParentNode.RemoveChild(node, true);
                }
            }
            return htmlDoc.DocumentNode.WriteContentTo();
            ;
        }
        private string CreateXPath()
        {
            string xPath = string.Empty;
            for (int i = 0; i < _deletableNodesXpath.Count; i++)
            {
                if (i != _deletableNodesXpath.Count - 1)
                {
                    xPath += string.Format("//{0}|", _deletableNodesXpath[i].ToString(CultureInfo.InvariantCulture));
                }
                else xPath += string.Format("//{0}", _deletableNodesXpath[i].ToString(CultureInfo.InvariantCulture));
            }
            return xPath;
        }
    }
