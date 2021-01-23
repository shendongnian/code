    struct S1 : IComparable {
      ...
    }
    
    S1 local = new S1();  // No box. 
    object obj = local;   // Box S1 instance into object
    IComparable comp = local;  // Box S1 instance into IComparable
    obj = "hello";  // String is a reference type, no boxing
