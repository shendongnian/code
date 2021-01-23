    using Bar = ProbablyAReallyBadIdeaToHaveAGlobalAnythingButHeyWhyNot.TestClass;
    
    namespace ProbablyAReallyBadIdeaToHaveAGlobalAnythingButHeyWhyNot
    {
      public static class TestClass
      {
        public static int TestFoo { get; set; }
      }
    }
    
    namespace Foo.SomeOtherNamespace
    {
      class MyClassThatDoesStuff
      {
        public void DoStuff()
        {
          Bar.TestFoo = 123;
        }
      }
    }
