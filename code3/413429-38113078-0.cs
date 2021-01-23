    using System;
    
    class Parent 
     {
        public Parent () {
        Console.WriteLine("Hey Its Parent.");
      }
    }
    class Derived : Parent 
      {
         public Derived () {
        Console.WriteLine("Hey Its Derived.");
       }
    }
    class OrderOfExecution {
          static void Main() {
            Derived obj = new Derived();
         }
    }
