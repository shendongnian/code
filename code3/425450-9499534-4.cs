    public static class TestClassFactory{
        public static T Create<T>(ITestInterface dep1, ITestInterface dep2) where T :TestClass, new(){
            return new T{FooBar = dep1, OtherDependency = dep2};
        }
    }
