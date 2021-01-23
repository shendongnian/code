    public List<System.Linq.Expressions.Expression<Func<E, bool>>> whereList = new List<Expression<Func<E, bool>>>();
    public List<E> ExecuteSelectFilter()
    {
    	System.Linq.Expressions.Expression<Func<E, bool>> whereFinal = c => true;
    
    	foreach (System.Linq.Expressions.Expression<Func<E, bool>> whereItem in whereList)
    	{
    		if (whereItem != null)
    		{
    			var invokedExpr = Expression.Invoke(whereFinal, whereItem.Parameters.Cast<Expression>());
    
    			whereFinal = Expression.Lambda<Func<E, bool>>
    					(Expression.AndAlso(whereItem.Body, invokedExpr), whereItem.Parameters);
    		}
    	}
    	return this.ObjectContext.CreateQuery<E>(EntitySetName).Where(whereFinal.Compile()).ToList();
    }
