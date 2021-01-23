    public IEnumerable<XElement> ElementsWithLocalName(this XContainer container,
        string localName)
    {
        return container.Elements().Where(x => x.Name.LocalName == localName);
    }
    public IEnumerable<XElement> ElementsWithLocalName<T>(
        this IEnumerable<T> source,
        string localName) where T : XContainer
    {
        return source.Elements().Where(x => x.Name.LocalName == localName);
    }
