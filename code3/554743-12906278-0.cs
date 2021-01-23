    class MyClass
    {
       int A {get;set;}
       
       public static bool operator ==(MyClass a, MyClass b)
       {
          return a.A == b.A;
       }
       public static bool operator !=(MyClass a, MyClass b)
       {
          return !(a == b);
       } 
    }
