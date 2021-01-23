    public class Foo
    {
       void TestMethod(Action<int, int> theDelegate) {}
       void TestMethod(Action<string> theDelegate) {}
    }
    
    foo.TestMethod(() => foo.AnotherMethod(1,2));
    foo.TestMethod(() => foo.AnotherMethod("I don't care method signature nor returning type"));
