    var local = instance;
    ↓ // volatile read barrier
    if (local == null)
    {
      lock (padlock)
      {
        ↓ // lock acquire barrier
        local = instance;
        ↓ // volatile read barrier
        if (local == null)
        {
          var ref = alloc Foo;
          ref.variable1 = 1; // inlined ctor
          ref.variable2 = 2; // inlined ctor
          ↑ // volatile write barrier
          instance = ref;
        }
        ↑ // lock release barrier
      }
    }
    local = instance;
    ↓ // volatile read barrier
    return local;
