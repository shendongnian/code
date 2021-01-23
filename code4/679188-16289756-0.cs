    public static class ExpressionCombiner
    {
    	public static Expression<Func<T, bool>> Or<T>(Expression<Func<T, bool>> a, Expression<Func<T, bool>> b)
    	{
    		var parameter = Expression.Parameter(typeof(T), "x");
    		var substituter = new SubstituteParameter(parameter, p => true);
    		
    	    var resultBody = Expression.Or(
    	        substituter.Visit(a.Body),
    	        substituter.Visit(b.Body));
    	
    	    Expression<Func<T, bool>> combined = Expression.Lambda<Func<T, bool>>(resultBody, parameter);
    		return combined;
    	}
    }
    
    public class SubstituteParameter : ExpressionVisitor
    {
    	private ParameterExpression toReplace;
    	private Func<ParameterExpression, bool> isReplacementRequiredFunc;
    	public SubstituteParameter(ParameterExpression toReplace, Func<ParameterExpression, bool> isReplacementRequiredFunc)
    	{
    		this.toReplace = toReplace;
    		this.isReplacementRequiredFunc = isReplacementRequiredFunc;
    	}
    	
    	protected override Expression VisitParameter(ParameterExpression node)
    	{
    		return isReplacementRequiredFunc(node) ? toReplace : node;
    	}
    }
