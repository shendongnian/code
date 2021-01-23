        string edgeSource = "n3";
        string edgeTarget = "n4";
        string newEdgeSource = "n0";
        string newEdgeTarget = "n4";
        IEnumerator<IEdge<object>> edgeEnumeratoer = g.Edges.GetEnumerator();
        edgeEnumeratoer.MoveNext();
        while (edgeEnumeratoer.Current != null)
        {
            var edge = edgeEnumeratoer.Current;
            string source = (string)(edge.Source);
            string target = (string)(edge.Target);
            if ((source.CompareTo(edgeSource) == 0) && (target.CompareTo(edgeTarget) == 0))
            {
                if (g.RemoveEdge(edge))
                {
                    IEdge<object> newEdge = new Edge<object>(newEdgeSource, newEdgeTarget);
                    g.AddEdge(newEdge);
                    break;
                }
                else
                {
                    Debug.WriteLine("Could not remove edge from graph.");
                }
            }
            edgeEnumeratoer.MoveNext();
        }
        graphLayout.Graph = g;
