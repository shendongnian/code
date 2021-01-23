    static void Main(string[] args)
    {
        var g = new Graph<int>();
        g.AddNodes(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
        g.AddArc(1, 2);
        g.AddArc(1, 3);
                
        g.AddArc(9, 6);
        g.AddArc(6, 7);
        g.AddArc(6, 8);
    
        g.AddArc(4, 5);
    
        var subGraphs = g.GetConnectedComponents();
    
    } 
