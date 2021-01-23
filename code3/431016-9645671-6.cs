    public struct RelationKey : IEquatable<RelationKey>
    {
        private readonly int source;
        private readonly int target;
        public int Source { get { return source; } }
        public int Target { get { return target; } }
        public RelationKey(int source, int target)
        {
            this.source = source;
            this.target = target;
        }
        public override bool Equals(object obj)
        {
            if (!(obj is RelationKey))
            {
                return false;
            }
            return Equals((RelationKey)obj);
        }
        public override int GetHashCode()
        {
            return source * 31 + target;
        }
        public bool Equals(RelationKey other)
        {
            return source == other.source && target == other.target;
        }
    }
