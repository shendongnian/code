    public static List<InfoNode> ExpandObject(InfoGrid grid, InfoNode owner, object obj)
    {
        List<InfoNode> nodes = new List<InfoNode>();
        if (obj == null)
            return nodes;
        PropertyInfo[] infos = obj.GetType().GetProperties(BindingFlags.FlattenHierarchy | BindingFlags.Instance | BindingFlags.Public);
        foreach (PropertyInfo info in infos)
            nodes.Add(new PropertyNode(grid, owner, obj, info));
        nodes = nodes.OrderBy(n => n.Name).ToList();
        return nodes;
    }
