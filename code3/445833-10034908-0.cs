    public static Dictionary<T, T> MergeDict<T, T>(Dictionary<T, T> a, Dictionary<T, T> b)
    {
         return b.Concat(a.Where(kvp => !b.ContainsKey(kvp.Key)).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
    }
 
