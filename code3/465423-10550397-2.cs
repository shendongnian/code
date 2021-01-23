    internal class C<T> where : T new()
    {
        public C() : this(new T()) {
        }
        private C(T t) {
            // Do additional initialization
        }
    }
