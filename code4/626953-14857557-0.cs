    public class Person 
    {
      Guid Id {get; set;}
      string Name {get; set;}
      // ad infinitum the truely unique things that relate to an Individual
    
      Address BusinessAddress {get; set;}
      Address HomeAddress {get; set;}
      Person Spouse {get; set;}
    }
    
    public class Address
    {
      Guid Id {get; set;}
      Line1 {get; set;}
      // ad infinitum all the truly unique things that relate to an address
    }
