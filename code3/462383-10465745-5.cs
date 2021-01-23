    class Test<T> where T : SomeObject, new()
    {
        public Test()
        {
            T t = new T();
            t.Foo();   // SomeObject.Foo gets called
        }
    }
