    public static string GetPath(XElement element)
    {
        return string.Join("/", element.AncestorsAndSelf().Reverse()
            .Select(e =>
                {
                    var index = GetIndex(e);
    
                    if (index == 1)
                    {
                        return e.Name.LocalName;
                    }
    
                    return string.Format("{0}[{1}]", e.Name.LocalName, GetIndex(e));
                }));
    
    }
    
    private static int GetIndex(XElement element)
    {
        var i = 1;
    
        if (element.Parent == null)
        {
            return 1;
        }
    
        foreach (var e in element.Parent.Elements(element.Name.LocalName))
        {
            if (e == element)
            {
                break;
            }
    
            i++;
        }
    
        return i;
    }
