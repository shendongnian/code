     public class Person
     {
         public Address Address { get; set; }
         ...
     }
     public class Instruct : Person
     {
         public void DoSomething()
         {
            Address.City = "Wellington";
         }
     }
     
