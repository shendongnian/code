    class Factory 
    {
        public static T Create<T, TVal>(TVal obj) where T : class, IFoo<TVal>, new()
        {
            return new T { Value = obj }; // return default(T);
        }
    }
    interface IFoo<TVal>
    {
        TVal Value { get; set; }
    }
    class Foo : IFoo<string>
    {
        public string Value { get; set; }
        public Foo() { }
    }
    // ...
    public T Get<T, TVal>(TVal obj) where T : class, IFoo<TVal>, new()
    {
        return Factory.Create<T, TVal>(obj);
    }
