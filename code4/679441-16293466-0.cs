    public static IEnumerable<XElement> ReadTransactions()
    {
        using (var reader = XmlReader.Create(file_name + ".xml"))
        {
            while (reader.ReadToFollowing("transact", eanuccNamespaceUri))
            {
                using (var subtree = reader.ReadSubtree())
                {
                    yield return XElement.Load(subtree);
                }
            }
        }
    }
