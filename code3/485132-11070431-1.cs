    public void RemoveEmptyElements(XElement element)
    {
        foreach (var e in element.Elements())
        {
            if (e.Value.Length == 0 && e.Elements().Count() == 0) e.Remove();
            else RemoveEmptyElements(e);
        }
    }
