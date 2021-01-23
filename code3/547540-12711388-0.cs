    int? i; // Same as Nullable<int> or Nullable<System.Int32> or System.Int32?
    object obj;
    bool test;
    i = null;
    test = i.HasValue; // ==> false
    test = i == null;  // ==> true
    obj = 5;           // The int is boxed here.
    test = obj is int;   // ==> true
    int x = (int)obj;  // ==> 5, the int is unboxed here.
    obj = null;
    test = obj is int?; // ==> false
    test = obj == null; // ==> true
