        public enum UpdateResult
        {
             Success,
             NoMyEntityFound,
             StaleData,
             InvalidRequest
        }
    
    
    public class MyService
    {
         ...
         ...
         public UpdateResult Update(...)
         {
    
              ...
              return UpdateResult.Success;
         }
    
    }
