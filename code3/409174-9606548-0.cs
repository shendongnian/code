    public interface IRepository<T>
    {
        IEnumerable<T> All { get; }
    }
    public abstract class Repository<T> : IRepository<T>
    {
        public IEnumerable<T> All
        {
            get
            {
                return new T[0];
            }
        }
    }
    public interface IFooRepository : IRepository<Foo>
    {
    }
    public class Foo
    {
    }
