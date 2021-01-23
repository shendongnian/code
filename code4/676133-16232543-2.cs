    public class MyService: IService
     {
        [QuotaOperationBehavior]
        public IList<Entity> FindAll()
        {
           //retrieves entities
            return entities;
        }
     }
 
