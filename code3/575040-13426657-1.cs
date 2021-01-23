    public class Person
    {
        public Person(string name, string sex)
        {
            _name = name;
            _sex = sex;
        }
    
        public string Name { get {return _name; }}
        public string Sex { get {return _sex; }}
    
        private readonly string _name, _sex;
    }
