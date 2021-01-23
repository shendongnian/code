    public class Person : IComparable<Person>
    {
        public string Forename { get; set; }
        public string Surname { get; set; }
        public int CompareTo(Person other)
        {
            int comp = Forename.CompareTo(other.Forename);
            if (comp != 0) {
                return comp
            }
            return Surname.CompareTo(other.Surname);
        }
    }
