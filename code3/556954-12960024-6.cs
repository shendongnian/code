    public class TestContext : DbContext
    {
        readonly Dictionary<Type, object> _sets;
    
        public DbSet<TestA> ATests { get; set; }
        public DbSet<TestB> BTests { get; set; }
    
        public TestContext()
        {
            _sets = new Dictionary<Type, object>
            {
                { typeof(TestA), ATests },
                { typeof(TestB), BTests }
            }
        }
    
        public IQueryable<T> getPool<T>() {
           return (IQueryable<T>)_sets[typeof(T)];
        }
    }
