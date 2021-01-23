    public class Toy
    {
        private Person _owner = null;
        public string Name { get; private set; }
        public Person Owner { 
             get { return _owner; }; 
             set {
                  if(_owner != null) throw new Exception();
                  _owner = value;
             }
        }
        public Toy(Person owner, string name)  
        { Owner = owner; Name = name; }
    }
