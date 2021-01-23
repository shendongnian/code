    public class ExtendedProperties
    {
      public string Name { get; set; }
      public string Value { get; set; }
    
    }
    
    public class MyModel
    {
      public ExtendedProperties[] Properties { get; set; }
      public string Name { get; set; }
      public int Id { get; set; }
    }
