    private static string GetAncestorNodeAsString(XElement el)
    {
        if (el.Parent == null)
            return String.Format("{0}[0]", el.Name.LocalName);
        else
            return String.Format("{0}.{1}[{2}]", 
                GetAncestorNodeAsString(el.Parent), 
                el.Name.LocalName, 
                el.ElementsBeforeSelf().Count(e => e.Name == el.Name));
    }
