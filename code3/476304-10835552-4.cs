    public class FooAttribute : Attribute
    {
      public String Description { get; set; }
    }
    class FooClass
    {
      private int fooProperty = 42;
      [Foo(Description="Foo attribute description")]
      public int FooProperty
      {
        get
        {
          return this.fooProperty;
        }
      }
    }
