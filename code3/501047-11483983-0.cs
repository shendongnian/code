    Interface ISubject
    {
        String name {get; set;}
        int age {get; set;}
    }
    Class Person : ISubject
    {
        // some other special properties for Person 
    }
    Class Alien : ISubject
    {
        // some other special properties for Alien 
    }
