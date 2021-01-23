    public class MyWCFService : IMyWCFContract
    {
         private MyDAO dao;
    
         public MyWCFService()
         {
            dao = new MyDAO(); 
         }
    
         public MyObject GetMyObjectById(int id)
         {
            return dao.GetMyObjectById(id);
         }
    }
