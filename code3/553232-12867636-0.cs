    public class UndirectedGraph<TVertex, TEdge>
    {
        Dictionary<TVertex, EdgeCollection> edges;
        class VertexCollection
        {
            UndirectedGraph<TVertex, TEdge> graph;
            public VertexCollection(UndirectedGraph<TVertex, TEdge> graph)
            { this.graph = graph; }
            public void Add(TVertex value)
            {
                this.graph.edges.Add(value, new EdgeCollection(this.graph));
            }
        }
        class EdgeCollection
        {
            public EdgeCollection(UndirectedGraph<TVertex, TEdge> graph) { }
        }
    }
