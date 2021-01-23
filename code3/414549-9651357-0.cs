    public static class PagingExtensions
    {
        private static readonly MethodInfo SkipMethodInfo = 
            typeof(Queryable).GetMethod("Skip");
            
        public static IQueryable<TSource> Skip<TSource>(
            this IQueryable<TSource> source, 
            Expression<Func<int>> countAccessor)
        {
            return Parameterize(SkipMethodInfo, source, countAccessor);
        }
    
        private static readonly MethodInfo TakeMethodInfo = 
            typeof(Queryable).GetMethod("Take");
    
        public static IQueryable<TSource> Take<TSource>(
            this IQueryable<TSource> source, 
            Expression<Func<int>> countAccessor)
        {
            return Parameterize(TakeMethodInfo, source, countAccessor);
        }
    
        private static IQueryable<TSource> Parameterize<TSource, TParameter>(
            MethodInfo methodInfo, 
            IQueryable<TSource> source, 
            Expression<Func<TParameter>>  parameterAccessor)
        {
            if (source == null) 
                throw new ArgumentNullException("source");
            if (parameterAccessor == null) 
                throw new ArgumentException("parameterAccessor");
            return source.Provider.CreateQuery<TSource>(
                Expression.Call(
                    null, 
                    methodInfo.MakeGenericMethod(new[] { typeof(TSource) }), 
                    new[] { source.Expression, parameterAccessor.Body }));
        }
    }
