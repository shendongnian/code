    public Test()
    {
          B b = new B();
          C c = new C();
    
          A_Collection.Add(b);
          A_Collection.Add(c);
    
          //so
          A_Collection[0].Bar // B::Bar 
          A_Collection[1].Bar //C::Bar 
    
    }
