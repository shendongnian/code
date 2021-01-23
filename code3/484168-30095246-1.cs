     public class BaseClass
        {
          public void PrintMethod()
          {
           Console.WriteLine("Calling base class method");
          }
         }
         public class ChildClass
         {
          public new void PrintMethod()
          {
           Console.WriteLine("Calling the child or derived class method");
           }
          }
          class Program
          {
           static void Main()
           {
            BaseClass bc = new ChildClass();
            bc.PrintMethod();
            }
           }
