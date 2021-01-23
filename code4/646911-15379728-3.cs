    public MyRepository()
    {
         using (MyEntities db = new MyEntities())
         {
         }
         //or
         using (MyEntities db = new MyEntities(connectionString))
         {
 
         }
    }
