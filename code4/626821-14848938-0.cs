    public CElement(int id, int numberOfNodes, int index, int[] nodes, CProperty property) : base(id)
        : base(id)
    {
        this.NumberOfNodes = numberOfNodes;
        this.Nodes = new int[numberOfNodes];
        this.Index = index;
        for (int i = 0; i < numberOfNodes; i++)
            this.Nodes[i] = nodes[i];
        Property = property;
    }
    public CProperty Property { get; set; }
    public int NumberOfNodes { get; set; }
    public int[] Nodes { get; set; }
    public int Index { get; set; }
    public CProperty Property { get; set; }
