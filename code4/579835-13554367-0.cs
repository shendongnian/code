    public class Person
    {
      public string Name { get; set; }
      ...
    }
    
    public class Career
    {
       public Person Person { get; set; }
       public IList<Company> Companies { get; set; }
       ...
    }
