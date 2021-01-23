            private static bool DictionaryEquals<TKey, TValue>(Dictionary<TKey, TValue> left, Dictionary<TKey, TValue> right)
            {
                var comp = EqualityComparer<TValue>.Default;
                if (left.Count != right.Count)
                {
                    return false;
                }
    
                if (typeof(TValue).IsGenericType && typeof(TValue).GetGenericTypeDefinition() == typeof(List<>))
                {
                    return left.All(pair => right.ContainsKey(pair.Key) && ListEquals((dynamic)pair.Value, (dynamic)right[pair.Key]));            
                }
                else
                {
                    return left.All(pair => right.ContainsKey(pair.Key) && comp.Equals(pair.Value, right[pair.Key]));
                }
            }
    
            private static bool ListEquals<TValue>(List<TValue> left, List<TValue> right)
            {
                if (left.Count != right.Count)
                {
                    return false;
                }
    
                return left.All(right.Contains);
            }
