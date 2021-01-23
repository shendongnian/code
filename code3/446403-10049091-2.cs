    public static class X
    {
        public static V Cast<V>(object o) { return (V)o; }
    }
    class C<T> {}
    class D<U>
    {
        public C<U> value;
        public D()
        {
            this.value = X.Cast<C<U>>(new C<bool>());
        }
    }
