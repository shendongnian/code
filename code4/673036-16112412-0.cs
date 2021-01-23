    public interface IFooBox<T>
        where T : IFoo
    {
       T Foo { get; }
    }
