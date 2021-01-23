    [ThreadStatic]
    private static string _foo;
    
    public static string Foo {
       get {
         if (_foo == null) {
             _foo = "the foo string";
         }
         return _foo;
       }
    }
