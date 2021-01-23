    public class TestContext : DbContext
    {
        public DbSet<TestA> ATests { get; set; }
        public DbSet<TestB> BTests { get; set; }
    
        public IQueryable<T> getPoolA<T>() where T : TestA {
           return (IQueryable<T>)ATests;
        }
        public IQueryable<T> getPoolB<T>() where T : TestB {
           return (IQueryable<T>)BTests;
        }
    }
