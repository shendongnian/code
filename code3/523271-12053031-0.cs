    public class OneDaoFactory
    {
        private EntityConnection conn; // initialize from outside
        
        //...
        public int AddTreatment(Dto dto)
        {
            using (Context bdd = new Context(conn))
            {
                //Make some changes in database
                bdd.SaveChanges();
            }
        }
    }
    public void Business()
    {
        EntityConnection conn = new EntityConnection(ConnectionString);
        OneDaoFactory.SetConnection( conn );
        SecondDaoFactory.SetConnection( conn );
        using( var ts = new TransactionScope())
        {
            OneDaoFactory.AddTreatment(dto);
            SecondDaoFactory.Add(dto2);
            throw new Exception("make a rollback);
            ts.Complete();
        }
    }
