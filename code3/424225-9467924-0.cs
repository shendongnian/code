	/// <summary>
	/// Extracts the PropertyInfo for the propertybeing accessed in the given expression.
	/// </summary>
	/// <remarks>
	/// If possible, the actual owning type of the property is used, rather than the declaring class (so if "x" in "() => x.Foo" is a subclass overriding "Foo", then x's PropertyInfo for "Foo" is returned rather than the declaring base class's PropertyInfo for "Foo").
	/// </remarks>
	/// <typeparam name="T"></typeparam>
	/// <param name="propertyExpression"></param>
	/// <returns></returns>
	internal static PropertyInfo ExtractPropertyInfo<T>(Expression<Func<T>> propertyExpression)
	{
	    if (propertyExpression == null)
	    {
	        throw new ArgumentNullException("propertyExpression");
	    }
	
	    var memberExpression = propertyExpression.Body as MemberExpression;
	    if (memberExpression == null)
	    {
	        throw new ArgumentException(string.Format("Expression not a MemberExpresssion: {0}", propertyExpression), "propertyExpression");
	    }
	
	    var property = memberExpression.Member as PropertyInfo;
	    if (property == null)
	    {
	        throw new ArgumentException(string.Format("Expression not a Property: {0}", propertyExpression), "propertyExpression");
	    }
	
	    var getMethod = property.GetGetMethod(true);
	    if (getMethod.IsStatic)
	    {
	        throw new ArgumentException(string.Format("Expression cannot be static: {0}", propertyExpression), "propertyExpression");
	    }
	
	    Type realType = memberExpression.Expression.Type;
	    if(realType == null) throw new ArgumentException(string.Format("Expression has no DeclaringType: {0}", propertyExpression), "propertyExpression");
	
	    return realType.GetProperty(property.Name);
	}
