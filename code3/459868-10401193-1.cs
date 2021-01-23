    public abstract class Dog {
    
      // Public is appropriate here as any consumer of Dog could access
      // Breed on an instantiated object
      public abstract string Breed { get; }
    
      // Public would be meaningless here. It's not legal to say 
      // 'new Dog' because 'Dog' is abstract. You can only say 
      // 'new Poodle' or 'new Bulldog'.  Only derived types like
      // Poodle or Bulldog could invoke the Dog constructor hence it's
      // protected
      protected Dog() { }
    }
    
    public class Poodle : Dog { } 
    public class Bulldog : Dog { }
