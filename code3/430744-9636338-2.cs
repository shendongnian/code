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
              ...Start Tran
              ...Load var m = MyEntity
              ...do the bare minimum here 
              ...m.Update()
              ...Commit Tran
              return UpdateResult.Success;
         }
    
    }
