    var result = temp.OrderBy(x => x.GetType().Name).ThenBy(x => GetPropValue(x));
    string GetPropValue(object o)
    {
        Type t = o.GetType();
        var p = t.GetProperty("ItemAName");
        if (p != null)
        {
            return (string)p.GetValue(o, null);
        }
        p = t.GetProperty("ItemBName");
        return (string)p.GetValue(o, null);
    }
