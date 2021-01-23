    public static void AddToList<T, U>(this IDictionary<T, List<U>> dict, T key, U elementToList)
    {
    
        List<U> list;
    
        bool exists = dict.TryGetValue(key, out list);
    
        if (exists)
        {
            dict[key].Add(elementToList);
        }
        else
        {
            dict[key] = new List<U>();
            dict[key].Add(elementToList);
        }
    
    }
