      public class Animal
      { public virtual Move() { debug.Print("Animal.Move()"); }
      public class Bird: Animal
      { public virtual override Move() { debug.Print("Bird.Move()");  }
      Animal x = new Bird();  
      x.Move();   // Will print "Bird.Move"
