	class ParameterRewriter<TTarget , TSource> : ExpressionVisitor {
		private ParameterExpression Source;
		private MemberExpression Target;
		public Expression<Func<TTarget , bool>> Rewrite( Expression<Func<TSource , bool>> predicate , Expression<Func<TTarget , TSource>> propertyNameExpression ) {
			var parameter = Expression.Parameter( typeof( TTarget ) );
			var propertyName = ( propertyNameExpression.Body as MemberExpression ).Member.Name;
			Source = predicate.Parameters.Single();
			Target = Expression.PropertyOrField( parameter , propertyName );
			var body = Visit( predicate.Body );
			return Expression.Lambda<Func<TTarget , bool>>(
				body ,
				parameter
			);
		}
		protected override Expression VisitParameter( ParameterExpression node ) {
			if ( node == Source ) {
				return Target;
			}
			return base.VisitParameter( node );
		}
	}
