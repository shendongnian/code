    struct MyStruct { public int V;}
    void UpdateStruct(MyStruct x)
    {
      x.V = 42; // updates copy of passed in object, changes will not be visible outside.
    }
    ....
    var local = new MyStruct{V = 13}
    UpdateStruct(local); // Hope to get local.V == 42
    if (local.V == 13) {
      // Expected. copy inside UpdateStruct updated,
      // but this "local" is untouched.
    }
