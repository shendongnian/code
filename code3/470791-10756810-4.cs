    class CachingQueryProvider : IQueryProvider
    {
        public object Execute(Expression expression)
        {
            var key = TranslateExpressionToCacheKey(expression);
        
            object cachedValue;
            if (_cache.TryGetValue(key, out cachedValue))
                return cachedValue;
    
            object result = _originalProvider.Execute(expression);
    
            // Won't compile because we don't know T at compile time
            IEnumerable<T> sequence = result as IEnumerable<T>;
            if (sequence != null && !(sequence is ICollection<T>)) 
            {
                result = sequence.ToList<T>();
            }
            
            _cache[key] = result; 
            
            return result;
        }
    }
