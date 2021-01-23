    // Leave the class Equals as reference equality
    class Person
    {
        readonly int Id;
        string FirstName { get; set; }
        string LastName { get; set; }
        string Address { get; set; }
        // ...
    }
    class PersonIdentityEqualityComparer : IEqualityComparer<Person>
    {
        public bool Equals(Person p1, Person p2)
        {
            if(p1 == null || p2 == null) return false;
            
            return p1.Id == p2.Id;
        }
        
        public int GetHashCode(Person p)
        {
            return p.Id.GetHashCode();
        }
    }
    class PersonValueEqualityComparer : IEqualityComparer<Person>
    {
        public bool Equals(Person p1, Person p2)
        {
            if(p1 == null || p2 == null) return false;
            
            return p1.Id == p2.Id &&
                   p1.FirstName == p2.FirstName; // etc
        }
        
        public int GetHashCode(Person p)
        {
            int hash = 17;
            
            hash = hash * 23 + p.Id.GetHashCode();
            hash = hash * 23 + p.FirstName.GetHashCode();
            // etc
            
            return hash;
        }
    }
