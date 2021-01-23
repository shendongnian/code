    public static void GetNodes(Node node)
    {
        if (node == null)
        {
            return;
        }
        Console.WriteLine(node.Name);
        foreach (var n in node.Nodes)
        {
            GetNodes(n);
        }
    }
