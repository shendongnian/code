    class SomeClass
    {
      public void StartOperation()
      {
        string name = typeof(SomeClass).FullName;
        ThreadManager.StartNew(name, () => RunOperation());
      }
    }
