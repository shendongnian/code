    public static string ReturnInnerXml()
    {
        var doc = XDocument.Parse(@"<root>Hello<child>World</child></root>");
        var root = doc.Root;
        if (root == null)
        {
            throw new InvalidOperationException("No root");
        }
        var inners = from n in root.Nodes()
                     select n;
        return String.Join(String.Empty, inners);
    }
