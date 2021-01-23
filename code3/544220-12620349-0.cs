    public static void GetNodes(Node node, List<Node> output)
    {
        if (node == null)
            return;
                    
        output.Add(node);
        Console.WriteLine(node.Name);
        
        foreach (var n in node.Nodes)
        {
            GetNodes(n, output);
        }
    }
