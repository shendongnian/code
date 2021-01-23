    static class Factory
    {
        public static Factory<T> FromConstructor<T>() where T : new()
        {
            return new Factory<T>(() => new T());
        }
    }
    class Factory<TProduct>
    {
        public Factory(Func<TProduct> build)
        {
            this.build = build;
        }
    
        public TProduct Build()
        {
            return build();
        }
    
        private Func<TProduct> build;
    }
