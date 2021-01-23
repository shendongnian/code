    class S
    {
      public int f;
      public S s;
    }
    {
      Func<S, S> sGetter = s => s.s; // okay
      Func<S, object> objectGetter = s => s.s; // okay
      objectGetter = sGetter; // also okay
    }
    {
      Func<S, int> intGetter = s => s.f; // okay
      Func<S, object> objectGetter = s => s.f; // still okay
      objectGetter = intGetter; // not okay
    }
