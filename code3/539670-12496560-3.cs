    public static IQueryable<TElement> IsDateBetween<TElement>(this IQueryable<TElement> queryable, Expression<Func<TElement, DateTime>> fromDate, Expression<Func<TElement, DateTime>> toDate, DateTime date)
            {
                var p = fromDate.Parameters.Single();
                Expression member = p;
    
                Expression fromExpression = Expression.Property(member, (fromDate.Body as MemberExpression).Member.Name);
                Expression toExpression = Expression.Property(member, (toDate.Body as MemberExpression).Member.Name);
    
                var after = Expression.LessThanOrEqual(fromExpression,
                     Expression.Constant(date, typeof(DateTime)));
    
                var before = Expression.GreaterThanOrEqual(
                    toExpression, Expression.Constant(date, typeof(DateTime)));
    
                Expression body = Expression.And(after, before);
    
                var predicate = Expression.Lambda<Func<TElement, bool>>(body, p);
                return queryable.Where(predicate);
            }
