    public class Dog
    {
      public string Name { get; set; } // PascalCase is a convention here
    
      public Dog(string name)
      {
        Name = name;
      }
    
      public IList<Dog> listOfDogs () // try to expose interfaces whenever possible
      {
        // blah blah
      }
    }
