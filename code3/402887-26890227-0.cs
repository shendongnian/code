	/// Perform the registration of custom methods
	/// </summary>
	public static void Register()
	{
	    if (!_registered)
	    {
		_registered = true;
		String str = null;
		ExpressionProcessor.RegisterCustomMethodCall(() => str.StartsWith(null), ProcessStartsWith);
		ExpressionProcessor.RegisterCustomMethodCall(() => str.EndsWith(null), ProcessEndsWith);
		ExpressionProcessor.RegisterCustomMethodCall(() => str.Contains(null), ProcessContains);
	    }
	}
	static ICriterion ProcessStartsWith(MethodCallExpression methodCallExpression)
	{
	    ExpressionProcessor.ProjectionInfo projection = ExpressionProcessor.FindMemberProjection(methodCallExpression.Object);
	    object value = ExpressionProcessor.FindValue(methodCallExpression.Arguments[0]) + "%";
	    return projection.CreateCriterion(Restrictions.Like, Restrictions.Like, value);
	}
	static ICriterion ProcessEndsWith(MethodCallExpression methodCallExpression)
	{
	    ExpressionProcessor.ProjectionInfo projection = ExpressionProcessor.FindMemberProjection(methodCallExpression.Object);
	    object value = "%" + ExpressionProcessor.FindValue(methodCallExpression.Arguments[0]);
	    return projection.CreateCriterion(Restrictions.Like, Restrictions.Like, value);
	}
	static ICriterion ProcessContains(MethodCallExpression methodCallExpression)
	{
	    ExpressionProcessor.ProjectionInfo projection = ExpressionProcessor.FindMemberProjection(methodCallExpression.Object);
	    object value = "%" + ExpressionProcessor.FindValue(methodCallExpression.Arguments[0]) + "%";
	    return projection.CreateCriterion(Restrictions.Like, Restrictions.Like, value);
	}
