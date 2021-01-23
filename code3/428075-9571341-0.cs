    struct WeightedRelation 
    { 
       public readonly int node1;
       public readonly int node2;
       public readonly int weight;
    }
    
    int[] Nodes = new int[1146445];
    
    List<WeightedRelation> Relations = new List<WeightedRelation>();
    Relations.Add(1, 2, 10);
    ...
