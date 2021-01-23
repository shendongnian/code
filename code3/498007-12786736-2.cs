    public class BusinessLogic
    {
        private IRepository<EntityType> repository;
        
        public BusinessLogic(IRepository<EntityType> repository)
        {
            this.repository = repository;
        }
        
        public void Add(EntityType obj)
        {
          bool isNew = // check if new
          if(isNew)
          {
            this.repository.Insert (obj)    
          }
          else
          {
            this.repository.Update(obj);
          }
        }
    }
