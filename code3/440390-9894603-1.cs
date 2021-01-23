    public class Edge : IEquatable<Edge>
    {
        ...
        public bool Equals(Edge other)
        {
            return (
                (other.Source == this.Source && other.Target == this.Target) ||
                (other.Target == this.Source && other.Source == this.Target));
        }
        public override int GetHashCode()
        {
            return (Source.GetHashCode() ^ Target.GetHashCode());
        }
    }
