    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly IEfDbContext _context;
        public void BulkInsert(IEnumerable<T> entities)
        {
            _context.BulkInsert(entities);
        }
        public void Truncate()
        {
            _context.Database.ExecuteSqlCommand($"TRUNCATE TABLE {typeof(T).Name}");
        }
     }
     // usage 
     DataAccess.TheRepository.Truncate();
     var toAddBulk = new List<EnvironmentXImportingSystem>();
     // fill toAddBulk from source system
     // ...
     DataAccess.TheRepository.BulkInsert(toAddBulk);
     DataAccess.SaveChanges();
