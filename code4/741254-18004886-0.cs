    class Person{
      Collection<Communications> comm {get; set;}
    }
    
    class Communication{
      Collection<PersonSender> person {get; set;}
      Collection<BuildingSender> building {get; set;}
    }
    
    class PersonSender{
      string name {get; set; }
      Collection<Posts> posts {get; set;}
    }
    
    class BuildingSender{
      string name {get; set; }
      Collection<Posts> posts {get; set;}
    }
