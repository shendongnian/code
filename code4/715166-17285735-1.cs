     public class Person
     {
         public Address Address { get; set; }
         ...
     }
     public class Instructor : Person
     {
         public void DoSomething()
         {
            Address.City = "Wellington";
         }
     }
     
