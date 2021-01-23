    public static Items ItemsFromStartItem(XElement start, XElement group)
    {
        return new Items
        {
            GroupNumber = (int)group.Attribute("group"),
            ItemNumber = (int)start.Attribute("value"),
            ItemText = start.NodesAfterSelf()
                .TakeWhile(n => n.NodeType != XmlNodeType.Element
                             || ((XElement)n).Name != "endItem")
                .OfType<XText>()
                .Select(t => t.Value)
                .Single()
        };
    }
    public static IEnumerable<Items> ItemsFromBlockOfData(
        XElement block, XElement group)
    {
        return block.Elements("startItem")
            .Select(start => ItemsFromStartItem(start, group));
    }
