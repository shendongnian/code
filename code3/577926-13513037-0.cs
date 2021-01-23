    public static IEnumerable<Node> GetTopologicalOrdering(IEnumerable<Node> roots)
    {
        var list=new List<Node>();
        var visited=new HashSet<Node>();
        Action<Node> visit=(n)=>
        {
           if(visited.Add(n)
           {
               foreach(Node child in n.Children)
               {
                   visit(child);
               }
               list.Add(n)
           }
        }
        
        foreach(Node n in roots)
        {
           visit(n);
        }
    
        return list.Reverse();
    }
    
