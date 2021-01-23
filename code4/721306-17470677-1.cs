    public static class FilterHelper {
    
        public static IQueryable<T> Filter(this IQueryable<T> queryable, Context context, int userId) {
            var entityName = typeof(T).Name;
            //get all filters for the current entity by userId, Select the needed values as a `List<Filter>()`
            //this could be done out of this method and used as a parameter
            var filters = context.EntityProperties
                          .Where(m => m.entityName == entityName && m.userId = userId)
                          .Include(m => m.PropertyValueList)
                          .Select(m => new Filter {
                              PropertyName = m.property,
                              Values = m.PropertyValueList.Select(x => x.value).ToList()
                          })
                          .ToList();
    
            //build the expression
            var parameter = Expression.Parameter(typeof(T), "m");
            
            var member = GetContains( filters.First(), parameter);
            member = filters.Skip(1).Aggregate(member, (current, filter) => Expression.And(current, GetContains(filter, parameter)));
            //the final predicate
            var lambda = Expression.Lambda<Func<T, bool>>(member, new[] { parameter });
            //use Where with the final predicate on your Queryable
            return queryable.Where(lambda);
        }
    
    //this will build the "Contains" part
    private static Expression GetContains(Filter filter, Expression expression)
        {
            Expression member = expression;
            member = Expression.Property(member, filter.PropertyName);
            var values = filter.Values.Select(m => Convert.ToInt32(m));
            var containsMethod = typeof(Enumerable).GetMethods().Single(
                method => method.Name == "Contains"
                          && method.IsGenericMethodDefinition
                          && method.GetParameters().Length == 2)
                          .MakeGenericMethod(new[] { typeof(int) });
            member = Expression.Call(containsMethod, Expression.Constant(values), member);
            return member;
        }
    }
