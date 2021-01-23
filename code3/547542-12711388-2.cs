    int? i; // Same as Nullable<int> or Nullable<System.Int32> or System.Int32?
    object obj;
    bool test;
    i = null;
    test = i.HasValue; // ==> false
    test = i == null;  // ==> true
    // Now comes the strange part
    obj = 5;           // The int is boxed here.
    // Debugger shows type of obj as "object {int}"
    test = obj is int;   // ==> true
    test = obj is int?;   // ==> true
    int x = (int)obj;  // ==> 5, the int is unboxed here.
    // But
    obj = null;
    // Debugger shows type of obj as "object"
    test = obj is int; // ==> false
    test = obj is int?; // ==> false
    test = obj == null; // ==> true
    // And
    i = 5;
    obj = i; // i is a Nullable<int>
    // Debugger shows type of obj as "object {int}"
    test = obj is int; // ==> true
    test = obj is int?; // ==> true
    test = obj == null; // ==> false
    i = null;
    obj = i;
    // Debugger shows type of obj as "object"
    test = obj is int; // ==> false
    test = obj is int?; // ==> false
    test = obj == null; // ==> true
