    public abstract class BaseEntity
    {
        public override abstract String ToString();
    }
    
    //all generic methods
    public interface IRepositoryBase<T>
        where T : BaseEntity, new()
    {
        T GetById(int id);
        IList<T> GetOrderedObjects();
    
    }
    
    //all methods specific to foo, which can't be in a generic class
    public interface IFooRepository :IRepositoryBase<Foo>
    {
        void Update(Foo model);
    }
    
    //implementation of generic methods
    public abstract class BaseClass<T> : IRepositoryBase<T>
        where T : BaseEntity, new() // ===> Add new() constraint here
    {
        public T GetById(int id)
        {
            return new T();
        }
        public IList<T> GetOrderedObjects() {
            var obj = this.GetById(5);
    
            //Dummy Code
            return new List<Foo>();
            //
        }
    }
    
    //implementation of Foo specific methods
    public class FooRepository : BaseClass<Foo>, IFooRepository
    {
        public void Update(Foo model) {
        //bla bla
        }
    }
