    public class ComparePersonsByName : IComparer<Peron>
    {
        public static readonly ComparePersonsByName Instance = new ComparePersonsByName();
        private ComparePersonsByName()
        {
        }
     
        public int Compare(Person x, Person y)
        {
            int comp = x.Forename.CompareTo(y.Forename);
            if (comp != 0) {
                return comp;
            }
            return x.CompareTo(y.Surname);
        }
    }
