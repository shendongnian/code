    public static IEnumerable<string> GetXPathValues(this XNode node, string xpath)
    {
        foreach (XObject xObject in (IEnumerable)node.XPathEvaluate(xpath))
        {
            if (xObject is XElement)
                yield return ((XElement)xObject).Value;
            else if (xObject is XAttribute)
                yield return ((XAttribute)xObject).Value;
        }
    }
