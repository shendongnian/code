        List<string> xpaths = new List<string>();
        foreach (HtmlNode node in doc.DocumentNode.DescendantNodes())
        {
                            if (node.Name.ToLower() == "img")
                            {
                                string src = node.Attributes["src"].Value;
                                if (string.IsNullOrEmpty(src))
                                {
                                    xpaths.Add(node.XPath);
                                    continue;
                                }
                            }
        }
    
        foreach (string xpath in xpaths)
        {
                doc.DocumentNode.SelectSingleNode(xpath).Remove();
        }
