    public class PersonSelector
    {
        private MyClass owner;
        
        public PersonSelector(MyClass owner)
        {
            this.owner = owner;
        }
    
        public bool this[Guid personGuid]
        {
           get {
              Person person = owner.GetPersonByGuid(personGuid);
              return person.IsSelected;
           }
           set {
              Person person = owner.GetPersonByGuid(personGuid);
              person.IsSelected = value;
           }
        }
    
    }
    
    public class MyClass
    {
        public MyClass()
        {
            this.IsSelected = new PersonSelector(this);
        }   
    
        public PersonSelector IsSelected { get; private set; }
        
        ...
    }
