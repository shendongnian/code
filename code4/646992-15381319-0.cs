    public class Foo
    {
      private Foo _foo;
      public Foo()
      {
        _foo = this;
      }
      public void InitializeFoo()
      {
        _foo = this;
      }
    }
