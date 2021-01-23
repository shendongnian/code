    class C<T> {}
    class D<U>
    {
        public C<U> value;
        public D()
        {
            this.value = (C<U>)(object)(new C<bool>());
        }
    }
