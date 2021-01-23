    if (instance == null)
    {
      lock (padlock)
      {
        if (instance == null)
        {
          instance = alloc space for Foo;
          instance.variable1 = whatever; // inside ctor
          instance.variable2 = whatever; // inside ctor
          /* ... */
          instance.variableN = whatever; // inside ctor 
        }
      }
    }
    return instance;
