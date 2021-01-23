    XDocument z = XDocument.Parse(s);
    var result = z.Root.Attributes().
        Where(a => a.IsNamespaceDeclaration).
        GroupBy(a => a.Name.Namespace == XNamespace.None ? String.Empty : a.Name.LocalName,
                a => XNamespace.Get(a.Value)).
        ToDictionary(g => g.Key, 
                     g => g.First());
