    class T1
    {
    }
    class T2
    {
        public static implicit operator T1(T2 item) { return new T1(); }
    }
