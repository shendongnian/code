    public class Person : IPerson
    {
        public readonly string _name;
        public string Name { get { return _name; } } 
    
        private readonly int _age;
        public int Age { get { return _age; } }
    
        public Person(string name, int age)
        {
           this._name = name;
           this._age = age;
        }
    }
