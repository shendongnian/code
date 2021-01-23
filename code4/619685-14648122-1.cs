    private static string GetAncestorNodeAsString(XElement e)
    {
        return e.AncestorsAndSelf().Reverse()
                .Aggregate(new StringBuilder(),
                (sb, a) => sb.AppendFormat("{0}{1}[{2}]", 
                              sb.Length == 0 ? "" : ".", a.Name, GetElementIndex(a)),
                sb => sb.ToString());
    }
