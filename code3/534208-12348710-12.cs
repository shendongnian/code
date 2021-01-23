    public static class Extensions
    {
    	public static string GetPropName<T>(this T t, Expression<Func<T, String>> exp)
    	{
    		return ((MemberExpression)exp.Body).Member.Name;
    	}
    }
    var propertyName = yourInstace.GetPropName(y => y.Name);
