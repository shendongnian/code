	public static class SystemLinqExpressionsExpressionExtensions {
		public static Expression Visit ( this Expression self , Func<Expression , Expression> visitor , bool recursive = false ) {
			return ExpressionDelegateVisitor.Visit ( self , visitor , recursive );
		}
		public static Expression Replace ( this Expression self , Expression source , Expression target ) {
			return self.Visit ( x => x == source ? target : x );
		}
		public static Expression<Func<T , bool>> CombineAnd<T> ( this Expression<Func<T , bool>> self , Expression<Func<T , bool>> other ) {
			var parameter = Expression.Parameter ( typeof ( T ) );
			return Expression.Lambda<Func<T , bool>> (
				Expression.AndAlso (
					self.Body.Replace ( self.Parameters[0] , parameter ) ,
					other.Body.Replace ( other.Parameters[0] , parameter )
				) ,
				parameter
			);
		}
	}
