    class Obj
    {
        double M(string s) { }
        Obj() { Method( "", M ); }
        public void Method<T, U>(T t, Func<T, U> f) { }
    }
