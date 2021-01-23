    public class context : Microsoft.WindowsAzure.StorageClient.TableServiceContext
    {
      public IQueryable<C1_Schema> C1_Schema
      {
        get
        {
          return this.CreateQuery<C1_Schema>("C1_Schema");
        }
      }
    }
