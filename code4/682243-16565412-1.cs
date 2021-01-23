    private HAP.HtmlNode FindParentNodeThatContainsClass(string classToFind, HAP.HtmlNode node)
    {
        string xPath = string.Format("//*[contains(@class,'{0}')]", classToFind);
        if ( node.SelectNodes(node.XPath + "//" + xPath ) != null && node.SelectNodes(node.XPath + "//" + xPath ).Count() >= 1)
        {
            return node;
        }
        else
        {
            if (node.ParentNode != null)
            {
                var parentNode = FindParentNodeThatContainsClass(xPath , node.ParentNode);
                return parentNode;
            }
            else
            {
                return null;
            }
        }
    }
