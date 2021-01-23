    class MyVisitor : ExpressionVisitor
    {
    	protected override Expression VisitBinary(BinaryExpression node)
    	{
    		if(CheckForMatch(node.Left))
    			return Expression.Equal(node.Left, Rewrite(node.Right));
    		
    		if(CheckForMatch(node.Right))
    			return Expression.Equal(Rewrite(node.Left), node.Right);
    			
    		return Expression.MakeBinary(node.NodeType, Visit(node.Left), Visit(node.Right));
    	}
    	
    	private bool CheckForMatch(Expression e)
    	{
    		MemberExpression me = e as MemberExpression;
    		if(me == null)
    			return false;
    			
    		if(me.Member.Name == "RowKey" || me.Member.Name == "PartitionKey")
    			return true;
    		else
    			return false;
    	}
    	
    	private Expression Rewrite(Expression e)
    	{
    		MethodInfo mi = typeof(Uri).GetMethod("EscapeDataString");
    	
    		return Expression.Call(mi, e);
    	}
    }
