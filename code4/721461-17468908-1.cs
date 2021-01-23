      void Foo() {
        Console.WriteLine("Foo");
      }
    
      void Bar() {
        Console.WriteLine("Bar");
      }
    
      ...
      Action x = Foo;
      Action y = x;
    
      if (Object.ReferenceEquals(x, y))
        Console.WriteLine("x was equal to y"); 
    
      // creates new delegate instance: 
      // x = x + Bar; 
      //   that is equal to 
      // x = Action.Combine(x, Bar);
      //   so x is not equal to y any longer:
      // x is a combined delegate (Foo + Bar)
      // y is a delegate to Foo (an old version of x)
      //   such a behavior is typical for operators (+, +=, etc.): 
      //   when we declare "public static MyType operator + (MyType a, MyType b)"
      //   it means that a new object "c" will be created that'll equal to sum of a and b 
      x += Bar; 
    
      if (Object.ReferenceEquals(x, y))
        Console.WriteLine("x is still equal to y");
    
      y();
