    public ReadOnlyCollection<string> GetProductsByCategory(string category)
    {
        List<string> products = new List<string>();
        using (XmlReader productsReader = GetProductsReader())
        {
            productsReader.MoveToContent();
            while (productsReader.Read())
            {
                if (productsReader.NodeType == XmlNodeType.Element &&
                    productsReader.LocalName == "product" &&
                    productsReader.GetAttribute("category") == category)
                {
                    products.Add(productsReader.GetAttribute("name"));
                }
            }
        }
        return new ReadOnlyCollection<string>(products);
    }
