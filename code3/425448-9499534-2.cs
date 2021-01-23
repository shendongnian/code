    public static class TestClassInitializer{
        public T Initialize<T>(this T t, ITestInterface dependency) where T:TestClass{
            t.FooBar = dependency;
            return t;
        }
    }
