    public static class QueryHelper
    {
      public static Expression<Func<T, bool>> ToPredicate<T> ( string propertyName, dynamic criteria )
        {
            ParameterExpression pe = Expression.Parameter( typeof( T ), "t" );
            Expression np = Expression.Property( pe, propertyName );
            ConstantExpression value = Expression.Constant( criteria );
    
            Expression e1 = Expression.Equal( np, value );
    
            var filter = Expression.Lambda<Func<T, bool>>( e1, pe );
    
            return filter;
        }
    }
