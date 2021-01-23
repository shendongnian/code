    public IList<string> GetList(string theType)
    {
        List<string> matchingProductNames = new List<string>();
        foreach (Product p in products)
        {
            if (p.Type == theType)
               matchingProductNames.Add(p.ProductName);
        }
        return matchingProductNames;
    }
