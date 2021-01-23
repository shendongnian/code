    public static class TestClassInitializer{
        public T Initialize<T>(this T t, ITestInterface dependency, IOtherDependency other) where T:TestClass{
            t.FooBar = dependency;
            t.OtherDependency = other;
            return t;
        }
    }
        
