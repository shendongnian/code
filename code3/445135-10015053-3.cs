    public abstract class ReadablePerson
    {
    
        public ReadablePerson(string name)
        {
            Name = name;
        }
        
        public string Name { get; protected set; }
                
    }
    
    public sealed class ReadOnlyPerson : ReadablePerson
    {
        public ReadOnlyPerson(string name) : base(name)
        {
        }
    }
    
    public sealed class ModifiablePerson : ReadablePerson
    {
        public ModifiablePerson(string name) : base(name)
        {
        }
        public new string Name { 
            get {return base.Name;}
            set {base.Name = value; }
        }
    }
