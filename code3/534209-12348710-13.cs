    public static class Extensions
    {
    	public static string GetPropName<T>(Expression<Func<T, String>> exp)
    	{
    		return ((MemberExpression)exp.Body).Member.Name;
    	}
    }
    var propertyName  = Extensions.GetPropName<YourClass>(y => y.Name);
