    public interface IFoo<T> where T : IFoo<T>
    {
        T Bar();
    }
    public class Foo : IFoo<Foo>
    {
        public Foo Bar()
        {
            //...
        }
    }
