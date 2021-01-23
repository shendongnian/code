    if (instance == null)
    {
      lock (padlock)
      {
        if (instance == null)
        {
          instance = alloc Foo;
          instance.variable1 = 1; // inlined ctor
          instance.variable2 = 2; // inlined ctor
        }
      }
    }
    return instance;
