     public class Base
       {
           public Base()
           {
               
           }
       }
       public class Derived : Base
       {
           public Derived()
           {
               
           }
       }
       // invokes, the  Base() construtor, and then the Derived() constructor
       var d = new Derived(); 
