    public partial class MyContext : DbContext
    {
        public MyContext (string ConnectionString)
            : base(ConnectionString)
        {
    		this.SetCommandTimeOut(300);
        }
    
    	public void SetCommandTimeOut(int Timeout)
    	{
    		var objectContext = (this as IObjectContextAdapter).ObjectContext;
    		objectContext.CommandTimeout = Timeout;
    	}
    }
