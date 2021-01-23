    public bool SearchEle(HtmlElement ele, string text)
    {
        foreach (HtmlElement child in ele.Children)
        {
            if (SearchEle(child, text))
                return true;
        }
        if (!string.IsNullOrEmpty(ele.InnerText) && ele.InnerText.Contains(text))
        {
            ele.ScrollIntoView(true);
            return true;
        }
         
        return false;
    }
