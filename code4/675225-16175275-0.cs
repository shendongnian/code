    public static class Creator<T>
    {
        public static void Create()
        {
            Func<T> mainThing = () => (T)SomeClass.Create(typeof(T));
        }
    }
