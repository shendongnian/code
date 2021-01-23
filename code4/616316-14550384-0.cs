    List<HtmlElement> toRemove = new List<HtmlElement>();
    foreach (HtmlElement element in Form.Children)
    {
        if (element.Id != string.Empty)
        {
            toRemove.Add(element);
        }
    }
    foreach (HtmlElement element in toRemove)
    {
        Form.RemoveChild(element);
    }
