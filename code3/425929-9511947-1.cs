    class Base
    { 
        virtual byte Method () 
        { 
              return 4; 
        } 
    } 
    class X : Base
    { 
        override byte Method () 
        { 
              return 5; 
        } 
    } 
    X x = new X();
    Base b = x;
    Console.WriteLine(x.Method()); // Prints "5"
    Console.WriteLine(b.Method()); // Prints "5"
