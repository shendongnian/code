    public class Holding
    {
       public Institution InstitutionId {get; set;}
       public string Designation {get; set;}
       public Owner Owner {get; set;}
       public Event Event {get; set;}   
    }
    public class Owner 
    {
      public int OwnerId {get; set;}
    }
    
    public class Event 
    {
      public int EventId {get; set;}
    }
    
    public class Institution 
    {
      public int InstitutionId {get; set;}
    }
