    void BreadthFirstTraversal(Graph graph, Vertex start)
    {
        var queue = new VertexQueue();
        var markSet = new VertexMarkSet();
        queue.Enqueue(start);
        markSet.Add(start);
        while(queue.NotEmpty())
        {
            var vertex = queue.Dequeue();
            foreach(var neighbour in graph.ListNeighbours(vertex))
            {
                if (!markSet.Contains(neighbour))
                {
                    markSet.Add(neighbour);
                    queue.Enqueue(neighbour);
                }
            }
         }
    }
