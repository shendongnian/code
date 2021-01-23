    // Simple string
    Write("string"); // "string"
    
    // binary operator with int on the right
    Write("x " + 2); // "x 2"
    
    // binary operator with int on the left
    Write(3 + " x"); // "3 x"
    
    // per the specification, calls Object.ToString
    Write("4 " + new EmptyClass()); // "4 StackOverflowCSharp.Program+EmptyClass"
    
    // the implicit conversion has higher precedence than Object.ToString
    Write("5 " + new ImplicitConversion()); // "5 Implicit"
    
    // when no implicit conversion is present, ToString is called, which
    // in this case is overridden by ToStringOnly
    Write("6 " + new ToStringOnly()); // "6 ToStringOnly"
