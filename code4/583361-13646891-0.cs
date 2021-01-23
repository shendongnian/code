    public interface IDataTransferObject
    {
            void CustomizeMeSomehow();
    }
    
    [DataContract]
    public class MyDataTransferObject : IDataTransferObject
    {
        public void CustomizeMeSomehow()
        {
              //Your custom logic here..
        }
    }
    
    public class MyService
    {
          public List<MyDataTransferObject> GetObjects()
          {
              List<MyDataTransferObjects> items = Repository.RetrieveResults();
               
              foreach (var item in items)
                   item.CustomizeMeSomehow();
    
              return items;
          }  
    }
