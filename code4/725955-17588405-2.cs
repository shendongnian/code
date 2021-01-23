    struct ConversionStub<T> {
        private readonly T input;
        public ConversionStub(T input) { this.input = input; }
        public TResult To<TResult>() {
            /* your code here */
        }
    }
