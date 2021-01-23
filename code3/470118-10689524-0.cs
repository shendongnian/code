	public static Expression<Func<TElement, bool>> BuildLikeExpression<TElement>( Expression<Func<TElement, string>> valueSelector, string value )
	{
		if ( valueSelector == null )
			throw new ArgumentNullException( "valueSelector" );
		var method = GetLikeMethod( value );
		var body = Expression.Call( method, Expression.Constant( value ), valueSelector.Body );
		var parameter = valueSelector.Parameters.Single();
		var expressionConvert = Expression.Convert( Expression.Constant( 0 ), typeof( int? ) );
		return Expression.Lambda<Func<TElement, bool>>( Expression.GreaterThan( body, expressionConvert ), parameter );
	}
