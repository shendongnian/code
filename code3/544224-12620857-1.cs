    public static IEnumerable<Node> GetNodes(Node node)
    {
        if (node == null) return null;
    
        var nodes = new List<Node>();
        nodes.Add(node);
    
        Console.WriteLine(node.Name);
    
        if (node.Nodes != null)
        {
            foreach (var n in node.Nodes)
            {
                nodes.AddRange(GetNodes(n));
            }
        }
    
        return nodes;
    }}
