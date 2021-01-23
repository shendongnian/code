    public static ReadOnlyCollection<string> GetProductsByCategory(string category)
    {
        using (var reader = GetProductsReader())
        {
            var doc = XDocument.Load(reader);
            var results = doc.Element("Products")
                .Elements("product")
                .Where(e => (string)e.Attribute("category") == category)
                .Select(e => (string)e.Attribute("name"))
                .ToList();
            return new ReadOnlyCollection<string>(results);
        }
    }
