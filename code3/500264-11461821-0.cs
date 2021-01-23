    struct S {}
    class C {}
    // or see `is` as per Jeff Mercado's comment
    typeof(ValueType).IsAssignableFrom(typeof(S)); // True
    typeof(object).IsAssignableFrom(typeof(S));    // True
    typeof(ValueType).IsAssignableFrom(typeof(C)); // False
    typeof(object).IsAssignableFrom(typeof(C));    // True
