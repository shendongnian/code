    public class Person : IEquatable<Person>
    {
        public string Name { get; set; }
    
        public string Email { get; set; }
    
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
    
            if (obj.GetType() != GetType())
            {
                return false;
            }
    
            return Equals((Person)obj);
        }
    
        public override int GetHashCode()
        {
            unchecked
            {    
                var hash = 17;
    
                hash = hash * 23 + (Name == null ? 0 : Name.GetHashCode());
                hash = hash * 23 + (Email == null ? 0 : Email.GetHashCode());
    
                return hash;
            }
        }
    
        public bool Equals(Person other)
        {
            if (other == null)
            {
                return false;
            }
    
            return Name == other.Name && Email == other.Email;
        }
    }
