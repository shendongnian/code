    public class BankRepository : RepositoryBase<Bank>, IBankRepository
    {
         private readonly ICacheManager cacheManager;
         private const string BanksAllCacheKey = "banks-all";
    
         public BankRepository(IDatabaseFactory databaseFactory, ICacheManager cacheManager)
              : base(databaseFactory)
         {
              Check.Argument.IsNotNull(cacheManager, "cacheManager");
    
              this.cacheManager = cacheManager;
         }
    
         public IEnumerable<Bank> FindAll()
         {
              string key = string.Format(BanksAllCacheKey);
    
              return cacheManager.Get(key, () =>
              {
                   var query = from bank in DatabaseContext.Banks
                               orderby bank.Name
                               select bank;
    
                   return query.ToList();
              });
         }
    }
