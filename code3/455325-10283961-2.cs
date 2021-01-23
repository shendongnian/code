    class NotDisposable
    {
      public void someMethod()
      {
        using(SomethingDisposable resource = new SomethingDisposable ())
        {...}
      }
    }
