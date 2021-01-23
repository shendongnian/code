    public sealed class EdgeComparer : IEqualityComparer<Edge>
    {
        public static EdgeComparer Default { get; private set; }
        static EdgeComparer()
        {
            Default = new EdgeComparer();
        }
        private EdgeComparer()
        {
        }
        public bool Equals(Edge x, Edge y)
        {
            return (
                (x.Source == y.Source && x.Target == y.Target) ||
                (x.Target == y.Source && x.Source == y.Target));
        }
        public int GetHashCode(Edge edge)
        {
            return (edge.Source.GetHashCode() ^ edge.Target.GetHashCode());
        }
    }
