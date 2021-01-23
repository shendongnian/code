        var g = new BidirectionalGraph<object, IEdge<object>>();
        const int max_n = 6;
        string[] vertices = new string[max_n];
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = string.Format("n{0}", i);
            g.AddVertex(vertices[i]);
        }
        // add edges to the graph
        g.AddEdge(new Edge<object>(vertices[0], vertices[1]));
        g.AddEdge(new Edge<object>(vertices[1], vertices[2]));
        g.AddEdge(new Edge<object>(vertices[1], vertices[3]));
        g.AddEdge(new Edge<object>(vertices[3], vertices[4]));
        g.AddEdge(new Edge<object>(vertices[3], vertices[5]));
        graphLayout.Graph = g;
