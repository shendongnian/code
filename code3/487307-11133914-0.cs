    class Edge
    {
        public string From { get; set; }
        public string To { get; set; }
    }
    
    class EdgeEqualityComparer : IEqualityComparer<Edge>
    {
        public bool Equals(Edge lhs, Edge rhs)
        {
            return (lhs.From == rhs.From && lhs.To == rhs.To) ||
                   (lhs.From == rhs.To && lhs.To == rhs.From)
        }
    
        public int GetHashCode(Edge e)
        {
            return e.From.GetHashCode() ^ e.To.GetHashCode();
        }
    }
