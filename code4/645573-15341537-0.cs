    public class Service {
      string Name { get;set;}
      int PaymentType { get;set;}
      float HourlyRate { get;set;}
    }
    
    public class MyModel { 
      ICollection<Service> services { get;set;}
      [...]
    }
