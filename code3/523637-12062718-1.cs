    public static explicit operator NodeA(NodeB b)
    {
        //if copy ctor is defined you can call one from the other, else
        NodeA a = new NodeA();
        a.Name = b.Name;
        a.Children = new List<NodeA>();
    
        foreach (NodeB child in b.Children)
        {
            a.Children.Add((NodeA)child);
        }
    }
