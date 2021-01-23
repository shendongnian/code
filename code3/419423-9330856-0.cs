    public class MyRepository : IMyRepository
    {
        private Context dbContext;
        IEnumberable<MyObject> GetObjects()
        {
             return dbContext.MyObjects;
        }
    }
