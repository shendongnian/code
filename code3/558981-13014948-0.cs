        var g = new BidirectionalGraph<object, IEdge<object>>();
        string n0 = "n0", n01 = "n0-1";
        string n1 = "n1", n12 = "n1-2";
        // add the vertices to the graph
        var vertices = new string[4] { n0, n01, n1, n12 };
        for (int i = 0; i < vertices.Length; i++)
        {
            g.AddVertex(vertices[i]);
        }
        // add edges to the graph
        g.AddEdge(new Edge<object>(vertices[0], vertices[1]));
        g.AddEdge(new Edge<object>(vertices[2], vertices[3]));
        graphLayout.Graph = g;
