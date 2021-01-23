    public class PersonNameEqualityComparer:IEqualityComparer<Person>
    {
        public int GetHashCode (Person obj)
        {
            return obj.Name.GetHashcode ();
        }
        public bool Equals (Person x, Person y)
        {
            return x.Name == y.Name;
        }
    }
