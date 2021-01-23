    public interface IOtherType<out T> {} // new
    public class OtherType<T> : IOtherType<T> { }
    
    public interface IInterface<T>
    {
        IOtherType<IInterface<T>> Operation(); // altered
    }
    public class Impl : IInterface<int>
    {
        public IOtherType<IInterface<int>> Operation()
        {
            return new OtherType<Impl>();
        }
    }
