    public class Bar
    {
      public static Expression<Func<T, bool>> ToPredicate<T> ( this T entityInstance, string propertyName, string criteria )
      {
        ParameterExpression pe = Expression.Parameter( typeof( T ), typeof( T ).Name );
                                        
        Expression lft = Expression.Property( pe, entityInstance.GetType().GetProperty( propertyName ) );
        MethodInfo methodeql = typeof( Bar).GetMethod( "IsEqualTo" );
        Expression[] parameters = new Expression[] { lft, Expression.Constant( criteria ) };
                                       
        Expression expression = Expression.Call( methodeql, parameters );
                                                
        Expression<Func<T, bool>> filterPredicate = Expression.Lambda<Func<T, bool>>( expression, new ParameterExpression[] { pe } );
        return filterPredicate;            
      }
    }
