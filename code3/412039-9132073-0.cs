    public class MyType {
      public string this[int index] {
        get { 
          switch (index) {
            case 1: return "hello";
            case 2: return "world";
            default: return "not found";
          }
        }
        set { ... }
      }
    }
    MyType t = ...;
    Console.WriteLine(t[0]);  // hello
    Console.WriteLine(t[1]);  // world
