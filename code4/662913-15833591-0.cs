    public class MyClass<TData>
    {
        public TData Data { get; set; }
    }
    public class MyClass<TData, TDataChildren, TChildren> : MyClass<TData>
        where TChildren : MyClass<TDataChildren>
    {
        public List<TChildren> List { get; set; }
    }
