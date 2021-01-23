    static class TestClass
    {
        public static TestClass<T> GetInstance<T>(T _t)
        {
            return new TestClass<T>(_t);
        }
    }
    
    class TestClass<T>
    {
        T t;
        public TestClass(T _t)
        {
            this.t = _t;
        }
        public T Value
        {
            get
            {
                return t;
            }
        }
        //...        
    }
