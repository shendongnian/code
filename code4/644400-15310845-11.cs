    public int?[,] CreateAdjMatrix()
    {
        int?[,] adj = new int?[AllNodes.Count, AllNodes.Count];
    
        for (int i = 0; i < AllNodes.Count; i++)
        {
            Node n1 = AllNodes[i];
    
            for (int j = 0; j < AllNodes.Count; j++)
            {
                Node n2 = AllNodes[j];
    
                var arc = n1.Arcs.FirstOrDefault(a => a.Child == n2);
    
                if (arc != null)
                {
                    adj[i, j] = arc.Weigth;
                }
            }
        }
        return adj;
    }
