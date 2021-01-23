    class Edge
    {
        public int Weight { get; set; }
        public Node Start { get; set; }
        public Node End { get set; }
    }
    class Node
    {
        private int cost;
        private IEnumerable<Edge> edges;
        // ...
        public int Cost()
        {
            int totalCost = cost;
            foreach (var edge in edges)
            {
                totalCost += edge.Weight * edge.End.Cost();
            }
            return totalCost;
        }
    }
