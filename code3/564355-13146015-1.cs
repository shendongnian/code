      public class Animal
      { public Move() { debug.Print("Animal.Move()"); }
      public class Bird: Animal
      { public Move() { debug.Print("Bird.Move()");  }
      Animal x = new Bird();  
      x.Move();   // Will print "Animal.Move"
