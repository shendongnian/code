    public interface IFoo<out T>
    {
        T Bar();
    }
    public class Baz<T> : IFoo<T>
    {
        public T Bar()
        {
            return default(T);
        }
    }
    public class Program
    {
        static void Main()
        {
            IFoo<IConvertible> foo = new Baz<string>();
        }
    }
