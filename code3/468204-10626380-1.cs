    public static Dictionary<K,V> ToDictionary<TSource, K, V>(
        this IEnumerable<TSource> source, 
        Func<TSource, K> keySelector, 
        Funct<TSource, V> valueSelector)
    {
      //TODO validate inputs for null arguments.
    
      Dictionary<K,V> output = new Dictionary<K,V>();
      foreach(TSource item in source)
      {
        //overwrites previous values
        output[keySelector(item)] = valueSelector(item); 
    
        //ignores future duplicates, comment above and 
        //uncomment below to change behavior
        //K key = keySelector(item);
        //if(!output.ContainsKey(key))
        //{
          //output.Add(key, valueSelector(item));
        //}
      }
    
      return output;
    }
