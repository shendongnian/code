    class MyClass<T> where T : MyInterface
    {
        public void callDelegate(Action<T> func)
        {
        }
    }
    class MyClass2
    {
        public void callDelegate<T>(Action<T> func)
            where T : MyInterface
        {
        }
    }
