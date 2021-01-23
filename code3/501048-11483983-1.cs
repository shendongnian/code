    Interface ISubject
    {
        // constractors
        public ISubject();
        public ISubject(ISubject);
        // properties
        String name {get; set;}
        int age {get; set;}
    }
    Class Person : ISubject
    {
        // some special properties for Person 
    }   
    Class Alien : ISubject
    {
        // some special properties for Alien 
    }
