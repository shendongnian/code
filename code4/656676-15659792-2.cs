    public static List<X> GetX(UIElement element)
    {
        var list = ((List<X>)(element.GetValue(XProperty)));
        if (list == null)
        {
            list = new List<X>();
            SetX(element, list);
        }
        return list;
    }
