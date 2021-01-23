    public class Person
    {
        public Person(string name, string sex)
        {
            _name = name;
            _sex = sex;
        }
    
        public String Name { get {return _name; }}
        public String Sex { get {return _sex; }}
    
        private readonly string _name, _sex;
    }
