        class MockComposite<T>
            where T : MyClass, new()
        {
            T _toTest;
    
            public MockComposite()
            {
                _toTest = new T();
            }
        }
    This means you can instantiate the mock class like this: `var mock = new MockComposite<ClassA>();` without the need for creating an instance of `ClassA` outside of the mock class.
        class MockComposite
        {
            MyClass _toTest;
    
            public MockComposite(MyClass toTest)
            {
                _toTest = toTest;
            }
        }
    This means you have to instantiate the mock class like this: `var mock = new MockComposite(new ClassA());`
