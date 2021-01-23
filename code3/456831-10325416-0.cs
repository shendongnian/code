    // replace parameter use anywhere in e1.Body with e2.Body
    var remover = new ParameterReplaceVisitor(e2.Body);
    var bb = remover.Visit(e1.Body);
    
    // create a new lambda with our amended body but still with e2 parameters i.e. the Customer
    var e3 = Expression.Lambda<Func<Customer, bool>>(bb, e2.Parameters);
    
    public class ParameterReplaceVisitor : ExpressionVisitor
    {
    	Expression _replace;
    	
    	public ParameterReplaceVisitor(Expression replace)
    	{
    		_replace = replace;
    	}
    	
    	protected override Expression VisitParameter(ParameterExpression node)
    	{
    		// when we encounter a parameter replace it
    		return _replace;
    	}
    }
