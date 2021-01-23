    public static IQueryable<TResult> GroupBy<TSource, TKey, TElement, TResult>(this IQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector, Expression<Func<TSource, TElement>> elementSelector, Expression<Func<TKey, IEnumerable<TElement>, TResult>> resultSelector)
            {
                if (source == null)
                    throw Error.ArgumentNull("source"); 
                if (keySelector == null)
                    throw Error.ArgumentNull("keySelector"); 
                if (elementSelector == null) 
                    throw Error.ArgumentNull("elementSelector");
                if (resultSelector == null) 
                    throw Error.ArgumentNull("resultSelector");
                return source.Provider.CreateQuery<TResult>(
                    Expression.Call(
                        null, 
                        ((MethodInfo)MethodBase.GetCurrentMethod()).MakeGenericMethod(typeof(TSource), typeof(TKey), typeof(TElement), typeof(TResult)),
                        new Expression[] { source.Expression, Expression.Quote(keySelector), Expression.Quote(elementSelector), Expression.Quote(resultSelector) } 
                        )); 
            }
    
    public static IQueryable<TResult> GroupBy<TSource, TKey, TResult>(this IQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector,Expression<Func<TKey, IEnumerable<TSource>, TResult>> resultSelector)
            {
                if (source == null)
                    throw Error.ArgumentNull("source"); 
                if (keySelector == null)
                    throw Error.ArgumentNull("keySelector"); 
                if (resultSelector == null) 
                    throw Error.ArgumentNull("resultSelector");
                return source.Provider.CreateQuery<TResult>( 
                    Expression.Call(
                        null,
                        ((MethodInfo)MethodBase.GetCurrentMethod()).MakeGenericMethod(typeof(TSource), typeof(TKey), typeof(TResult)),
                        new Expression[] { source.Expression, Expression.Quote(keySelector), Expression.Quote(resultSelector) } 
                        ));
            } 
