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
      // so x is not equal to y any longer 
      x += Bar; 
    
      if (Object.ReferenceEquals(x, y))
        Console.WriteLine("x is still equal to y");
    
      y();
