    public class DataAccess {
       private EFEntities _dbContext { get; set; }
    
       public EfEntities GetDbContext() {
            if (_dbContext != null) {
                 return _dbContext;
            } else {
                _dbContext = new EFEntities(.....);
                return _dbContext;
            }
       }
    }
