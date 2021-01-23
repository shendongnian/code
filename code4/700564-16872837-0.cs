    public static class FooExtensions
    {
      public static Foo WithSomething(this Foo foo)
      {
        //do your thing with foo
        ....
        return foo;
      }
      public static Foo WithOtherthing(this Foo foo)
      {
         //do your thing with foo
        ....
         return foo;
      }
    }
