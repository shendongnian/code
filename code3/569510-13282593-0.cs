    private static IEnumerable<List<Dictionary<String,Int32>>> foo = new Collection<List<Dictionary<String,Int32>>>(); // this is completely concrete
    
    static void DoSomething<TBaz>(IEnumerable<List<Dictionary<TBaz,Int32>>> baz) { // this is generic because TBaz is not specified
        
       List<TBaz> someList = new List<TBaz>(); // you can use the undefined TBaz because it's listed in the generic method's type arguments.
    }
    
    static void Main() {
        DoSomething( foo ); // the compiler will infer TBaz from the String argument used in the foo field
    }
