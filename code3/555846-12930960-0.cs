    static void Main(string[] args)
    {
        Node rootNode = new Node();
        rootNode.Name = "root";
        Node node1 = new Node();
        node1.Name = "child 1";
        Node node2 = new Node();
        node2.Name = "child 2";
        rootNode.Children.Add(node1);
        rootNode.Children.Add(node2);
        Node node3 = new Node();
        node3.Name = "child 3";
       
        node1.Children.Add(node3);
       
        Traverse(rootNode);
        Console.WriteLine("Reverse: ");
        TraverseReverse(rootNode);
    }
    private static void Traverse(Node node)
    {
        Console.WriteLine(node.Name);
        for (int index = 0; index < node.Children.Count;index++ )
        {
            Traverse(node.Children[index]);
        }            
    }
    private static void TraverseReverse(Node node)
    {
        Console.WriteLine(node.Name);
        for (int index = node.Children.Count-1; index >=0; index--)
        {
            TraverseReverse(node.Children[index]);
        }
    }     
