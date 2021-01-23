    public abstract class A
    {
        class A_Impl<T> : A
        {
            private T val;
            public A_Impl(T val) { this.val = val; }
            public T Value { get { return val; } }
        }
        public static A Create(int i) { return new A_Impl<int>(i); }
        public static A Create(string str) { return new A_Impl<string>(str); }
    }
