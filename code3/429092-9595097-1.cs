    public interface IBaz<U> 
    {
    }
    public class Baz<U> : IBaz<U>
    {
    }
    public interface IFoo<T, U> where T : IBaz<U> where U: Bar, new()
    {
    }    
    public class Foo<U> : IFoo<Baz<U>, U>
        where U: Bar, new()
    {
    }
