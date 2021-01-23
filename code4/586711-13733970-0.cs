      public IEnumerable<MyBaseClass> EnumerateWithOptions<T>()
      {
          foreach (MyBaseClass thingy in MyCustomCollection())
          {
             if (thingy.GetType() == typeof(T))
             { yield return thingy; };
          }
      }
