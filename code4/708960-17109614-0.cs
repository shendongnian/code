    public class AISDbContext : DbContext
    {
        public void ApplyFilters(IList<IFilter<AISDbContext>> filters)
        {
            foreach(var filter in filters)
            {
                filter.DbContext = this;
                filter.Apply();
            }
        }
    }
    
    public interface IFilter<T> where T : DbContext
    {
        T DbContext {get; set;}
        void Apply();
    }
    
    public class AdminRoleFilter : IFilter<AISDbContext>
    {
        public AISDbContext _dbContext {get; set;}
        public void Apply()
        {
            _dbContext.Address = new FilteredDbSet(_dbContext, d => d.haspermissions = "Admin");
        }
    }
