    void Main()
    {
       // creates a clause like 
       // select * from Menu where MenuText like '%ASD%' or ActionName like '%ASD%' or....
    	var items = Menu.Filter("ASD").ToList();
    }
    
    // Define other methods and classes here
    public static class QueryExtensions
    {
        public static IQueryable<T> Filter<T>(this IQueryable<T> query, string search)    
        {           
            var properties = typeof(T).GetProperties().Where(p => 
    				/*p.GetCustomAttributes(typeof(System.Data.Objects.DataClasses.EdmScalarPropertyAttribute),true).Any() && */
    				p.PropertyType == typeof(String));        
    		
            var predicate = PredicateBuilder.False<T>();
            foreach (var property in properties )
    		{
               orPredicate = predicate.Or(CreateLike<T>(property,search));
    		}
            return query.AsExpandable().Where(orPredicate);
        }
    	private static Expression<Func<T,bool>> CreateLike<T>( PropertyInfo prop, string value)
        {       
            var parameter = Expression.Parameter(typeof(T), "f");
            var propertyAccess = Expression.MakeMemberAccess(parameter, prop);                    
            var like = Expression.Call(propertyAccess, "Contains", null, Expression.Constant(value,typeof(string)));
    
            return Expression.Lambda<Func<T, bool>>(like, parameter);       
        }
    
    }
