    interface IService //pure business logic, no knowledge of WCF
    {
    	double Add(double a, double b);
    }
    
    class NonWcfService : IService //pure business logic
    {
    	public double Add(double a, double b)
    	{
    		return a + b;
    	}
    }
    
    [ServiceContract]
    interface IServiceContract //wcf-bound (because of the attributes)
    {
    	[OperationContract]
    	double Add(double a, double b);
    }
    
    class WcfService : IServiceContract //wcf-bound delegates calls to pure business logic
    {
    	IService sourceService;
    	
    	public WcfService(IService sourceService)
    	{
    		this.sourceService = sourceService;	
    	}
    
    	public double Add(double a, double b)
    	{
    		return sourceService.Add(a,b);
    	}
    }
