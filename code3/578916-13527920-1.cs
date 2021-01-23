    // Example of service for applying filter
    public GetProductsResponse GetProducts(GetProductsRequest request)
    {
        // base expression is true, ie always returns everything
        Expression<Func<ProductEntity, bool>> filterExpression = i => true;
        // subsequent filters narrow base expression results
        if (!request.IncludeDeleted)
            filterExpression = filterExpression.And(i => i
                .IsDeleted == false);
        if (request.AnotherCondition != null)
            filterExpression = filterExpression.And(i => 
                i.AnotherCondition == request.AnotherCondition);
        // etc.
        var products = _dataContext.Products.Where(filterExpression);
        // you probably want to transform products into some sort of model specific class
            
        return new GetProductsRequest
        {
            products = products;
        };
    }
    // Extension methods for Linq And and Or helpers
    public static class Utility
    {
        public static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
        {
            // build parameter map (from parameters of second to parameters of first)
            var map = first.Parameters.Select((f, i) => new { f, s = second.Parameters[i] }).ToDictionary(p => p.s, p => p.f);
    
            // replace parameters in the second lambda expression with parameters from the first
            var secondBody = ParameterRebinder.ReplaceParameters(map, second.Body);
    
            // apply composition of lambda expression bodies to parameters from the first expression 
            return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
        }
    
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.And);
        }
    
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.Or);
        }
    }
