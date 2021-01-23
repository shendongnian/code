    public abstract class Repository<T>
    {
        private IObjectSet objectSet;
        protected void Add(T obj)
        {
            this.objectSet.AddObject(obj);
        }
        protected void Delete(T obj)
        {
            this.objectSet.DeleteObject(obj);
        }
        protected IEnumerable<T>(Expression<Func<T, bool>> where)
        {
            return this.objectSet.Where(where);
        }
    }
    public interface IFooRepository
    {
        void DeleteFoo(Foo foo);
        IEnumerable<Foo> GetItalianFoos();
    }
    public class FooRepository : Repository<Foo>, IFooRepository
    {
        public void DeleteFoo(Foo foo)
        {
            this.Delete(foo);
        }
        public IEnumerable<Foo> GetItalianFoos()
        {
            return this.Find(foo => foo.Country == "Italy");
        }
    }
