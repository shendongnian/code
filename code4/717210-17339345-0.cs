    // You could turn this into a struct if you wanted.
    public sealed class IdPair : IEquatable<IdPair>
    {
        private readonly int first;
        private readonly int second;
        public int First { get { return first; } }
        public int Second { get { return second; } }
        public IdPair(int first, int second)
        {
            this.first = first;
            this.second = second;
        }
        public override int GetHashCode()
        {
            // This is order-neutral.
            // Could use multiplication, addition etc instead - the point is
            // that {x, y}.GetHashCode() must equal {y, x}.GetHashCode()
            return first ^ second; 
        }
        public override bool Equals(object x)
        {
            return Equals(x as IdPair);
        }
        public bool Equals(IdPair other)
        {
            if (other == null)
            {
                return false;
            }
            return (first == other.first && second == other.second) ||
                   (first == other.second && second == other.first);
        }
    }
