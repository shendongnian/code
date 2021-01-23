    public class TestContext : DbContext
    {
        public DbSet<TestA> ATests { get; set; }
        public DbSet<TestB> BTests { get; set; }
    
        public IQueryable<T> getPool<T>() {
           return (typeof(T) == typeof(TestA))
                      ? (IQueryable<T>)ATests
                      : (IQueryable<T>)BTests;
        }
    }
