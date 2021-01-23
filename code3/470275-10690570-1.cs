    class Event
    {
      int EventId { get; set; }
      ICollection<ContactEvent> ContactEvents { get; set; }
    }
    class ContactEvent
    {
      int EventId {get;set;}
      int ContactId {get;set;}
      public virtual Event Event {get; set;}
      public virtual Contact Contact {get;set;}
    }
  
    class Contact
    {
       int ContactId { get; set; }
       ICollection<ContactEvent> ContactEvents { get; set; }
       ICollection<Relation> Relations { get; set; }
    }
    
    class Relation
    {
      int RelationId { get; set; }
      string Name { get; set; }
      public virtual Contact Contact {get; set}
    }   
