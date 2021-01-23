    class PersonNameEqualityComparer : IEqualityComparer<Person>
    {
        public bool Equals(Person x, Person y)
        {
            return x.Name == y.Name;
        }
        public int GetHashCode(Person obj)
        {
           return obj.Name.GetHashCode();
        }
    }
