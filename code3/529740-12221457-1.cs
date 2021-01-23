    public static void RemoveDescendants(IList<Node> list)
    {
        for (int index = 0; index < list.Count; index++)
            RemoveDescendants(list[index], list);
    }
    private static void RemoveDescendants(Node node, IList<Node> list)
    {
        foreach (var child in node.children)
        {
            list.Remove(child);
            RemoveDescendants(child, list);
        }
    }
