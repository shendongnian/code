    static IEnumerable<Node> Parents(this IEnumerable<Node> nodes, int startId)
    {
        Node node = nodes.Where(n => n.Id = startId).Single();
        yield return node;
        while (node.ParentId != 0)
        {
            node = nodes.Where(n => n.Id = node.ParentId).Single();
            yield return node;
        }
    }
