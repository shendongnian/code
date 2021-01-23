    public class ItemRepository : IRepository<Item>
    {
        private readonly GenericEntities DB;
        public ItemRepository(GenericEntities db)
        {
             this.DB = db;                            
        } 
    
        public IQueryable<Item> GetAll()
        {
            return DB.Set<Item>();
        }   
    }
