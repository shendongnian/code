    public static class PropHelper<T>
    {
    	public static string PropName<R>(Expression<Func<T,R>> exp)
    	{
    		var mem = exp.Body as MemberExpression;
    		if(mem != null) return mem.Member.Name;		
    		throw new ArgumentException("Invlaid Property Name");
    	}
    }
