    public class PersonNameEqualityComparer:IEqualityComparer<Person>
    {
        public void GetHashCode (Person obj)
        {
            return obj.Name.GetHashcode ();
        }
        public void Equals (Person x, Person y)
        {
            return x.Name == y.Name;
        }
    }
