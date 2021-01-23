    // example 1 - single parameter of type dynamic
    private static void Sum( dynamic args ) { }
    
    // will not compile; Sum() expects a single parameter whose type is not
    // known until runtime
    Sum( 1, 2, 3, 4, 5 );
    // example 2 - variable number of dynamically typed arguments
    private static void Sum( params dynamic[] args ) { }
    // will compile
    Sum( 1, 2, 3, 4, 5 );
