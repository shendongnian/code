    public struct Foo{
       public int x;
    }
    
    //value semantics
    Foo x = new Foo()
    Foo y = x;
    
    //reference semantics
    object xx = new object();
    object yy = xx
    
    Object.ReferenceEquals(x,y); // <-- returns false;
    Object.ReferenceEquals(xx,yY); // <-- returns false;
