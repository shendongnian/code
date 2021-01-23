    class constType<T> where T : struct
    {
        public T GetT()
        {
            return new T();
        }
    
        public string[] GetArraySomehow()
        {
            var len = Marshal.SizeOf(typeof(T));
            return new string[len];
        }
    }
    
    class testTypeInClass
    {
        public void test<T>(T message) where T : struct
        {
    
        }
    }
    
    class MyClass
    {
        void Test()
        {
            var constType = new constType<int>();
    
            var typeInClass = new testTypeInClass();
    
            var t = constType.GetT();
    
            typeInClass.test(t);
    
        }
    }
