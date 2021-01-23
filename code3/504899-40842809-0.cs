    public static class Extensions
    {
        public static KeyValuePair<TKey, TValue> ToKeyValuePair<TKey, TValue>(this Object obj)
        {
            // if obj is null throws exception
            Contract.Requires(obj != null);
            
            // gets the type of the obj parameter
            var type = obj.GetType();
            // checks if obj is of type KeyValuePair
            if (type.IsGenericType && type == typeof(KeyValuePair<TKey, TValue>))
            {
    
                return new KeyValuePair<TKey, TValue>(
                                                        (TKey)type.GetProperty("Key").GetValue(obj, null), 
                                                        (TValue)type.GetProperty("Value").GetValue(obj, null)
                                                     );
    
            }
            // if obj type does not match KeyValuePair throw exception
            throw new ArgumentException($"obj argument must be of type KeyValuePair<{typeof(TKey).FullName},{typeof(TValue).FullName}>");   
     }
