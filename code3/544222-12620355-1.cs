    public static IEnumerable<Node> GetNodes(Node node)
    {
        if (node == null)
        {
            yield break;
        }
        yield return node;
        foreach (var n in node.Nodes)
        {
            foreach(var innerN in GetNodes(n))
            {
                yield return innerN;
            }
        }
    }
