	/// <summary>
	/// Extension method that enables .Contains(obj) like functionality for Linq to Entities.
	/// 
	/// Source: http://www.velocityreviews.com/forums/t645784-linq-where-clause.html
	/// </summary>
	/// <typeparam name="TElement">The element being evaluated by the Where clause</typeparam>
	/// <typeparam name="TValue">The value to match</typeparam>
	/// <param name="valueSelector">Lamda for selecting matching values</param>
	/// <param name="values">IEnumerable of the values</param>
	/// <returns>Expression consumable by Linq to Entities that reflects semantics of .Contains(value)</returns>
	/// <remarks>
	/// Usage:
	/// 
	/// Replace expression like 
	/// 
	/// where ChildrenIDs.Contains(items.CategoryID)
	/// 
	/// with
	/// 
	/// .Where((BuildContainsExpression<Item, int>(item => item.CategoryID, ChildrenIDs))
	/// 
	/// NOTE: If the item collection is large, the SQL query will be as well.
	/// </remarks>
	static public Expression<Func<TElement, bool>> BuildContainsExpression<TElement, TValue>(Expression<Func<TElement, TValue>> valueSelector, IEnumerable<TValue> values)
	{
		if (null == valueSelector)
		{
			throw new ArgumentNullException("valueSelector");
		}
		if (null == values) { throw new ArgumentNullException("values"); }
		ParameterExpression p = valueSelector.Parameters.Single();
		if (!values.Any())
		{
			return e => false;
		}
		var equals = values.Select(value => (Expression)Expression.Equal(valueSelector.Body, Expression.Constant(value, typeof(TValue))));
		var body = equals.Aggregate<Expression>((accumulate, equal) => Expression.Or(accumulate, equal));
		return Expression.Lambda<Func<TElement, bool>>(body, p);
	}
