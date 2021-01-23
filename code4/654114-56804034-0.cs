    public class A
    {
      // ...
    }
    public class B<T> : A
    {
      // ...
    }
    public class Program
    {
      public static A MakeA() { return new A(); }
      
      public static A MakeB() { return new B<string>(); }
      
      public static void Visit<T>(B<T> b)
      {
        Console.WriteLine("This is B with type "+typeof(T).FullName);
      }
      
      public static void Visit(A a)
      {
        Console.WriteLine("This is A");
      }
      
      public static void Main()
      {
        A instA = MakeA();
        A instB = MakeB();
        // This calls the appropriate methods.
        Visit((dynamic)instA);
        Visit((dynamic)instB);
        // This calls Visit(A a) twice.
        Visit(instA);
        Visit(instB);
      }
    }
