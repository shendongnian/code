    public static class Examples
    {
        public static Expression<Func<MyEntity, short?>> SelectPropertyOne()
        {
            return x => x.PropertyOne;
        }
        public static Expression<Func<MyEntity, short?>> SelectPropertyTwo()
        {
            return x => x.PropertyTwo;
        }
        public static Expression<Func<TEntity, bool>> BetweenNullable<TEntity, TNull>(Expression<Func<TEntity, Nullable<TNull>>> selector, Nullable<TNull> minRange, Nullable<TNull> maxRange) where TNull : struct
        {
            var param = Expression.Parameter(typeof(TEntity), "entity");
            var member = Expression.Invoke(selector, param);
            Expression hasValue = Expression.Property(member, "HasValue");
            Expression greaterThanMinRange = Expression.GreaterThanOrEqual(member,
                                                 Expression.Convert(Expression.Constant(minRange), typeof(Nullable<TNull>)));
            Expression lessThanMaxRange = Expression.LessThanOrEqual(member,
                                              Expression.Convert(Expression.Constant(maxRange), typeof(Nullable<TNull>)));
            Expression body = Expression.AndAlso(hasValue,
						  Expression.AndAlso(greaterThanMinRange, lessThanMaxRange));
						  
            return Expression.Lambda<Func<TEntity, bool>>(body, param);
        }
    }
