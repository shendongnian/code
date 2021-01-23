    public partial class PersonCollection : IList<Person>
    {
        //the underlying dictionary
        private Dictionary<string, Person> _dictionary;
        public PersonCollection()
        {
            _dictionary = new Dictionary<string, Person>();
        }
        public void Add(Person p)
        {
            _dictionary.Add(p.Name, p);
        }
        public Person this[string name]
        {
            get
            {
                return _dictionary[name];
            }
        }
    }
