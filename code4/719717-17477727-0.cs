    public IQueryable GetItemsFromContainsClause(Type type, IEnumerable<string> items)
        {
            IUnitOfWork session = new SandstoneDbContext();
            var method = this.GetType().GetMethod("ContainsExpression");
            method = method.MakeGenericMethod(new[] { type });
            var lambda = method.Invoke(null, new object[] { "Codigo", items });
            var dbset = (session as DbContext).Set(type);
            var originalExpression = dbset.AsQueryable().Expression;
            var parameter = Expression.Parameter(type, "");
            var callWhere = Expression.Call(typeof(Queryable), "Where", new[] { type }, originalExpression, (Expression)lambda);
            return dbset.AsQueryable().Provider.CreateQuery(callWhere);
            
        }
        public static Expression<Func<T, bool>> ContainsExpression<T>(string propertyName, IEnumerable<string> values)
        {
            var parameterExp = Expression.Parameter(typeof(T), "");
            var propertyExp = Expression.Property(parameterExp, propertyName);
            var someValue = Expression.Constant(values, typeof(IEnumerable<string>));
            var containsMethodExp = Expression.Call(typeof(Enumerable), "Contains", new[] { typeof(string) }, someValue, propertyExp);
            return Expression.Lambda<Func<T, bool>>(containsMethodExp, parameterExp);
        }
