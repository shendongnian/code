    Interface ISubject
    {
        // properties
        String name {get; set;}
        int age {get; set;}
    }
    Class Person : ISubject
    {
        // contractors
        public Person ()
        {
            ...
        }
        public Person (ISubject subject)
        {
             name = subject.name;
             age = subject.age;
        }
        ...
    }
    Class Alien : ISubject
    {
        // contractors
        public Alien ()
        {
            ...
        }
        public Alien (ISubject subject)
        {
             name = subject.name;
             age = subject.age;
        }
        ... 
    }
