    public interface IFoo
    {
        // Members which don't depend on the type parameter
    }
    public interface IFoo<T> : IFoo
    {
        // Members which all use T
    }
