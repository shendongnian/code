    public abstract class Repository<T>
    {
        private ObjectContext context;
        protected void Delete(T obj)
        {
            this.context.DeleteObject(obj);
        }
    }
    public interface IFooRepository
    {
        void DeleteFoo(Foo foo);
    }
    public class FooRepository : Repository<Foo>, IFooRepository
    {
        public void DeleteFoo(Foo foo)
        {
            this.Delete(foo);
        }
    }
