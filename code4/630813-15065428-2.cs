    public static void FixDefaultXmlNamespace(this XElement xelem, 
            XNamespace documentDefaultNamespace)
    {
        if (xelem.Attributes().Any(x => x.Name.Namespace == documentDefaultNamespace))
        {
            var attrs = xelem.Attributes().ToArray();
            for (int i = 0; i < attrs.Length; i++)
            {
                var attr = attrs[i];
                if (attr.Name.Namespace == documentDefaultNamespace)
                {
                    attrs[i] = new XAttribute(attr.Name.LocalName, attr.Value);
                }
            }
            xelem.ReplaceAttributes(attrs);
        }
        foreach (var elem in xelem.Elements())
            elem.FixDefaultXmlNamespace(documentDefaultNamespace);
    }
