    using System;
    class Program {
    void Main()
    {
      var x = new A<int>();
      // x.Print("abc");  - compile time error
      x.Print(1); // Print only accepts same Int32 type 
      x.Print2(1);     // Print2 can use as the same Int32 used for class
      x.Print2("abc"); // as well any other type like string.
    }
    public class A<T>
    {
       public void Print(T arg)
       {
          Console.WriteLine("Print:{0} = {1}", arg.GetType().FullName, arg);
       }
       public void Print2<T>(T arg)
       {
	Console.WriteLine("PRINT2:{0} = {1}", arg.GetType().FullName, arg);
       }
    }
    }
