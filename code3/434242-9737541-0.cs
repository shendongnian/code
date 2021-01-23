    public sealed class TraceAttribute : OnMethodBoundaryAspect
    {
    	private readonly string category;
    	private TraceArgumentService argumentService;
    	private TraceService traceService;
    
    	public string Category { get { return category; } }
    
    	public TraceAttribute(string category)
    	{
    		this.category = category;
    	}
    
    	public override void RuntimeInitialize(System.Reflection.MethodBase method)
    	{
    		base.RuntimeInitialize(method);
    		this.argumentService = new TraceArgumentService();
    		this.traceService = new TraceService();
    	}
    
    
    	public override void OnEntry(MethodExecutionArgs args)
    	{                
    		traceService.Write(
    			argumentService.GetDeclaringTypeName(args),
    			argumentService.GetMethodName(args),
    			category);
    
    	}
    }
    
    public class TraceArgumentService
    {
    	public string GetDeclaringTypeName(MethodExecutionArgs args)
    	{
    		return args.Method.DeclaringType.Name;
    	}
    
    	public string GetMethodName(MethodExecutionArgs args)
    	{
    		return args.Method.Name;
    	}
    }
    
    public class TraceService
    {
    	public void Write(string declaringTypeName, string methodName, string category)
    	{
    		Trace.WriteLine(string.Format("Entering {0}.{1}.",
    			declaringTypeName, methodName), category);
    	}
    }
