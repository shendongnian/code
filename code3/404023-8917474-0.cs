    public abstract class MyClass
    {
      private SomeType _someField = null; // Never touch this field in any member but
                                          // the SomeProp property
                                          // Maybe use Lazy<SomeType> to make this more obvious.
      protected SomeType CreateSomeType();
      public SomeType SomeProp
      {
        get
        {
          return _someField = _someField ?? CreateSomeType();
        }
      }
    }
