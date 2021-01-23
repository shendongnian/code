    public class SortDefinition
    {
    	public SortDirection Direction
    	{
    		get;
    		set;
    	}
    
    	public LambdaExpression Expression
    	{
    		get;
    		set;
    	}
    }
    
    internal static class MethodHelper
    {
    	static MethodHelper()
    	{
    		Include = GetIncludeMethod();
    		OrderBy = GetOrderByMethod();
    		OrderByDescending = GetOrderByDescendingMethod();
    	}
    
    	public static MethodInfo OrderBy
    	{
    		get;
    		private set;
    	}
    
    	public static MethodInfo OrderByDescending
    	{
    		get;
    		private set;
    	}
    
    	private static MethodInfo GetOrderByMethod()
    	{
    		Expression<Func<IQueryable<object>, IOrderedQueryable<object>>> expr =
    			q => q.OrderBy((Expression<Func<object, object>>)null);
    
    		return ((MethodCallExpression)expr.Body).Method.GetGenericMethodDefinition();
    	}
    
    	private static MethodInfo GetOrderByDescendingMethod()
    	{
    		Expression<Func<IQueryable<object>, IOrderedQueryable<object>>> expr =
    			q => q.OrderByDescending((Expression<Func<object, object>>)null);
    
    		return ((MethodCallExpression)expr.Body).Method.GetGenericMethodDefinition();
    	}
    }
