    public class EFEmployeeRepository
    {
        //leave everything else as it is
    	
        public void Initialise(int tenantID = 0)
        {
            context = new EFDbContext(tenantID);
        }
    }
