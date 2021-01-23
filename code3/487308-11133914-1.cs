    class Edge
    {
        public string From { get; set; }
        public string To { get; set; }
    }
    
    class EdgeEqualityComparer : IEqualityComparer<Edge>
    {
        public bool Equals(Edge lhs, Edge rhs)
        {
            return (lhs.From.Equals(rhs.From) && lhs.To.Equals(rhs.To)) ||
                   (lhs.From.Equals(rhs.To) && lhs.To.Equals(rhs.From));
        }
    
        public int GetHashCode(Edge e)
        {
            return e.From.GetHashCode() ^ e.To.GetHashCode();
        }
    }
