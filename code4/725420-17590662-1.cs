    public static class TypeExtensions
    {
        //http://bradhe.wordpress.com/2010/07/27/how-to-tell-if-a-type-implements-an-interface-in-net/
        public static bool IsImplementationOf(this Type baseType, Type interfaceType)
        {
            return baseType.GetInterfaces().Any(interfaceType.Equals);
        }
    }
    public interface IRepository<T> 
    {
        void Delete(T entity);
    }
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        public void Delete(T entity)
        {
            if (typeof(T).IsImplementationOf(typeof(ICanBeSoftDeleted)))
            {
                ((ICanBeSoftDeleted)entity).IsDeleted = true;
                //etc
            }
            else
            {
                //hard delete
            }
        }
    }
    public class Customer : ICanBeSoftDeleted
    {
        public bool IsDeleted { get; set; }
    }
    public class UOW
    {
        private IRepository<T> GetRepository<T>()
        {
            return (IRepository<T>)new RepositoryBase<T>();
        }
        public IRepository<Customer> CustomerRepository
        {
            get
            {
                return GetRepository<Customer>();
            }
        }
    }
    public interface ICanBeSoftDeleted
    {
        bool IsDeleted { get; set; }
    }
