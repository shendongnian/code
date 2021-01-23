    class Test<T> where T : SomeObject, new()
    {
        public Test()
        {
            T t = new T();
            object t1 = t;
            Console.WriteLine(t.ToString());
            Console.WriteLine(t1.ToString());
        }
    }
