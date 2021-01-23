    public static bool ContainsKeyPattern<T>(this Dictionary<string, T> nodes, string search) 
    {
         return nodes.Keys.Any(k => Regex.Matches(k, search));
    }
    public static T GetItemByKeyPattern<T>(this Dictionary<string, T> dict, string search) 
    {
         return
             (from p in dict
              where Regex.Matches(p.Key, search)
              select p.Value)
             .First();
    }
