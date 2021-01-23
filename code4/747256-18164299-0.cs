    public class BusinessEntityUpdatedEvent : CompositePresentationEvent
    {
       public object Entity { get; set; }
       //or
 
       // if your entities share a common base class
       public EntityBase Entity { get; set; }   
       //or
       public justAnything ofAnyType { get; set; }
       public orEvenMore ofAnotherType { get; set; }
    }
