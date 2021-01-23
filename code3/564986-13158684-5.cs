    public struct Foo{
       public int x;
       public Foo(int x){
           this.x = x;
       }
    }
    
    //value semantics
    Foo x = new Foo(1)
    Foo y = x;
    
    //reference semantics
    object xx = new object();
    object yy = xx
    
    Object.ReferenceEquals(x,y); // <-- returns false;
    Object.ReferenceEquals(xx,yY); // <-- returns true;
