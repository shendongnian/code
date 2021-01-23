    class MyType
    {
        void Foo(object obj) ...
    }
    class MyType<T> : MyType
    {
        void Foo(T obj)
        {
            base.Foo(obj);
        }
    }
