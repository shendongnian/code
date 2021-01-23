    public class SampleObject : IEquatable<SampleObject>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Equals(SampleObject other)
        {
            if (ReferenceEquals(this, other))
                return true;
            if (ReferenceEquals(other, null) || ReferenceEquals(this, null))
                return false;
            return Id.Equals(other.Id);
        }
        public override int GetHashCode() 
        {
            return Id;
        }
    }
