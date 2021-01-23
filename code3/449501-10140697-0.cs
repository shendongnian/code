    public class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        private IDbContext context;
        public EfRepository(IDbContext dbContext)
        {
            this.context = context;
        }
        public void Do()
        {
            var dbSet = this.context.Set<T>();
        }
    }
