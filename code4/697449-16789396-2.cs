    class Mutable : IEquatable<Mutable>
    {
        public int Id { get; set; }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            var mutable = obj as Mutable;
            if (mutable == null)
            {
                return false;
            }
            return this.Equals(mutable);
        }
        public bool Equals(Mutable other)
        {
            return Id.Equals(other.Id);
        }
    }
