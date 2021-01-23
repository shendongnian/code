    public class Repository<T> where T : class
    {
        private DbContext dbContext;
        private DbSet<T> DbSet { get; set }
        public Repository(dbContext)
        {
           this.dbContext = dbContext;
           this.DbSet = this.dbContext.DbSet<T>();
        }
    
        public void Delete(int id)
        {
             T entity = DbSet.Find(id);
             DbSet.Remove(entity);
             dbContext.Save();
        }
    
    }
 
