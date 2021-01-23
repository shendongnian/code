    foreach(Edge edge in Edges)
    {
        Edge edge2 = new Edge(edge.V2, edge.V1);
        if (!dict.ContainsKey(edge) && !dict.ContainsKey(edge2))
        {
            dict[edge] = false; // first time we've seen this edge, so put it in dictionary
        }
        else if (!dict.ContainsKey(edge) && dict.ContainsKey(edge2))
        {
            dict[edge2] = true; // a bidirectional edge
        }
    }
