    private static string Parse(XPathNavigator xNav, XPathExpression xPathExpression)
    {
        string result = string.Empty;
        object selected = xNav.Evaluate(xPathExpression.Clone());
    
        XPathNodeIterator iterator = selected as XPathNodeIterator;
        if (iterator != null)
        {
            result = string.Concat(iterator.OfType<XPathNavigator>()
                                           .Select(n => n.TypedValue + "#"));
        }
        else
        {
            result = selected.ToString();
        }
    
        return result;
    }
