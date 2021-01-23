    public static ReadOnlyCollection<string> GetProductsByCategory(string category)
    {
        var results = new List<string>();
        var settings = new XmlReaderSettings
        {
            IgnoreWhitespace = true,
            IgnoreComments = true,
        };
        using (var reader = XmlReader.Create(GetProductsReader(), settings))
        {
            reader.MoveToContent();
            reader.ReadStartElement("Products");
            do
            {
                if (reader.IsStartElement("product"))
                {
                    if (reader.MoveToFirstAttribute())
                    {
                        string currentCategory = null;
                        string currentName = null;
                        do
                        {
                            switch (reader.Name)
                            {
                            case "category":
                                currentCategory = reader.ReadContentAsString();
                                break;
                            case "name":
                                currentName = reader.ReadContentAsString();
                                break;
                            }
                        } while (reader.MoveToNextAttribute());
                        if (currentCategory == category && currentName != null)
                            results.Add(currentName);
                    }
                }
            } while (reader.ReadToNextSibling("product"));
        }
        return new ReadOnlyCollection<string>(results);
    }
