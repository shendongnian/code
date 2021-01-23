    // Simple string, okay
    Write("JustAString"); // JustAString
    			
    // Error: cannot convert from 'int' to 'string'
    //Write(2); 
    
    // EmptyClass cannot be converted to string implicitly,
    // so we have to call ToString ourselves. In this case
    // EmptyClass does not override ToString, so the base class
    // Object.ToString is invoked
    //Write(new EmptyClass()); // Error
    Write(new EmptyClass().ToString()); // StackOverflowCSharp.Program+EmptyClass
    
    // implicit conversion of a user-defined class to string
    Write(new ImplicitConversion()); // Implicit
    
    // while ToStringOnly overrides ToString, it cannot be
    // implicitly converted to string, so we have to again
    // call ToString ourselves. This time, however, ToStringOnly
    // does override ToString, and we get the user-defined text
    // instead of the type information provided by Object.ToString
    //Write(new ToStringOnly()); // ERROR
    Write(new ToStringOnly().ToString());  // "ToStringOnly"
