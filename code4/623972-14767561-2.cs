    public static decimal SumPaths(XmlNode source, string nodePath, string formula)
    {
        decimal sum = 0;
        foreach (XPathNavigator item in source.CreateNavigator().Select(nodePath))
        {
            sum += Convert.ToDecimal(item.Evaluate(formula));
        }
        return sum;
    }
