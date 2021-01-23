    static class SomeStaticClass {
       static readonly SomeClass sSomeClass = new SomeClass();
       public static void DoSomething() {
          sSomeClass.DoSomething();
       }
       public static bool TestSomething(string pValue) {
          sSomeClass.TestSomething(pValue);
       }
    }
    ...
    SomeStaticClass.DoSomething();
    if (SomeStaticClass.TestSomething(someValue))
       ...
