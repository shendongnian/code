    void MyMethod<T>(T t)    // no "where" constraints on T
    {
      if (typeof(T) = typeof(GreatType))
      {
        var tConverted = (GreatType)(object)t;
        // ... use tConverted here
      }
      // ... other stuff
    }
