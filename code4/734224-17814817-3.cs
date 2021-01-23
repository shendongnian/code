    // An interface which implements IDbSet<T> and adds on the method you want
    public interface IExtendedDbSet<T> : IDbSet<T>
        where T : class
    {
        DbSqlQuery<T> SqlQuery(string sql, object[] parameters);
    }
    // Implement this interface by wrapping around a regular DbSet<T>.
    // You implement all the methods and properties by just wrapping the DbSet<T>
    // calls
    public class ExtendedDbSet<T> : IExtendedDbSet<T>
        where T : class
    {
        private readonly DbSet<T> _dbSet;
        public ExtendedDbSet(DbSet<T> dbSet) { _dbSet = dbSet; }
        DbSqlQuery<T> IExtendedDbSet<T>.SqlQuery(string sql, object[] parameters)
        {
            return _dbSet.SqlQuery(sql, parameters);
        }
        T IDbSet<T>.Add(T entity) { return _dbSet.Add(entity); }
        T IDbSet<T>.Attach(T entity) { return _dbSet.Attach(entity); }
        TDerivedEntity IDbSet<T>.Create<TDerivedEntity>() { return _dbSet.Create<TDerivedEntity>(); }
        T IDbSet<T>.Create() { return _dbSet.Create(); }
        T IDbSet<T>.Find(params object[] keyValues) { return _dbSet.Find(keyValues); }
        ObservableCollection<T> IDbSet<T>.Local { get { return _dbSet.Local; } }
        T IDbSet<T>.Remove(T entity) { return _dbSet.Remove(entity); }
        IEnumerator<T> IEnumerable<T>.GetEnumerator() { return ((IEnumerable<T>)_dbSet).GetEnumerator(); }
        IEnumerator IEnumerable.GetEnumerator() { return ((IEnumerable)_dbSet).GetEnumerator(); }
        Type IQueryable.ElementType { get { return ((IQueryable)_dbSet).ElementType; } }
        Expression IQueryable.Expression { get { return ((IQueryable)_dbSet).Expression; } }
        IQueryProvider IQueryable.Provider { get { return ((IQueryable)_dbSet).Provider; } }
    }
    // A regular context class, no special interfaces to implement or
    // custom properties or anything.
    public class MyContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
    }
    // An interface representing your context, which exposes extended DbSet<T>
    // for your sets. Also define SaveChanges() and whatever else you may need
    // to call on your context object.
    public interface IMyContext
        : IDisposable
    {
        IExtendedDbSet<Car> Cars { get; }
        int SaveChanges();
    }
    // A wrapper around your regular context. For each set, return an
    // ExtendedDbSet<T> wrapper.
    public class MyContextWrapper : IMyContext
    {
        private readonly MyContext _myContext;
        public MyContextWrapper(MyContext myContext) { _myContext = myContext; }
        IExtendedDbSet<Car> IMyContext.Cars
        {
            get { return new ExtendedDbSet<Car>(_myContext.Cars); }
        }
        void IDisposable.Dispose()
        {
            _myContext.Dispose();
        }
        int IMyContext.SaveChanges()
        {
            return _myContext.SaveChanges();
        }
    }
    // Define your context variable as IMyContext, and create it
    // by creating a wrapper around a regular context. The properties
    // of the interface will be extended wrappers around your sets.
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (IMyContext context = new MyContextWrapper(new MyContext()))
            {
                Console.WriteLine(context.Cars.SqlQuery("select 1", new object[0]));
            }
        }
    }
