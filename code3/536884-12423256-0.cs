    public string ResolvePropertyName<TEntity>(Expression<Func<TEntity>> expression)
    {
	try {
		if (expression == null) {
			Throw New ArgumentNullException("propertyExpression")
		}
		object memberExpression = expression.Body as MemberExpression;
		if (memberExpression == null) {
			Throw New ArgumentException("The expression is not a member access expression.", "propertyExpression")
		}
		object property = memberExpression.Member as PropertyInfo;
		if (property == null) {
			Throw New ArgumentException("The member access expression does not access a property.", "propertyExpression")
		}
		object getMethod = property.GetGetMethod(true);
		if (getMethod.IsStatic) {
			Throw New ArgumentException("The referenced property is a static property.", "propertyExpression")
		}
		return memberExpression.Member.Name;
	} catch (Exception ex) {
		return string.Empty;
	}
    }
