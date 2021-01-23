    public abstract class BaseEntity
    {
        public override abstract String ToString();
    }
    public interface IRetriever<T>
        where T : BaseEntity, new()
    {
        T GetById(int id);
    }
    public interface IFooRepository<T> : IRetriever<T>
        where T : BaseEntity, new()
    {
        IList<Foo> GetOrderedObjects();
    }
    public abstract class BaseClass<T> : IRetriever<T>
        where T : BaseEntity, new() // ===> Add new() constraint here
    {
        public T GetById(int id)
        {
            return new T();
        }
    }
    public class FooRepository : BaseClass<Foo>, IFooRepository<Foo>
    {
        public IList<Foo> GetOrderedObjects()
        {
            var obj = this.GetById(5);
            return new List<Foo>();
        }
    }
