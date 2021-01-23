    class Obj
    {
        void Handler( int a, int b ) { }
        Obj() { Method( "", Handler ); }
        public void Method<T, U>( T t, Action<U, U> action ) { }
    }
