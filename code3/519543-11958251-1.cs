    // repository
    interface Users {
      // implementation executes SQL COUNT in case of relation DB
      bool IsNameUnique(String name);
      // implementation will call IsNameUnique and throw if it fails
      void Add(User user);
    }
