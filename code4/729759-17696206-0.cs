    public class Person : IEquatable<Person>
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public bool Equals(Person other)
        {
            if (other == null)
                return false;
            return Object.ReferenceEquals(this, other) ||
                this.Id == other.Id &&
                this.Name == other.Name;
        }
        public override bool Equals(object obj)
        {
            return this.Equals(obj as Person);
        }
        public override int GetHashCode()
        {
            int hash = this.Id.GetHashCode();
            if (this.Name != null)
                hash ^= this.Name.GetHashCode();
            return hash;
        }
    }
