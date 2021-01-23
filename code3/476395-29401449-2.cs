    static class SomeStaticClass {
       static readonly SomeClass sSomeClass = new SomeClass();
       public static SomeClass SomeProperty { get { return sSomeClass; } }
    }
    ...
    SomeStaticClass.SomeProperty.DoSomething();
    if (SomeStaticClass.SomeProperty.TestSomething(someValue))
       ...
