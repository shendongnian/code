    public static bool ContainsKeyPattern<T>(this Dictionary<string, T> nodes, string search) 
    {
         var return = Nodes.Keys.Any(k => Regex.Matches(search, k));
    }
    public static T GetItemByKeyPattern<T>(this Dictionary<string, T> dict, string search) 
    {
         return
             (from p in dict
              where Regex.Matches(search, p.Key)
              select p.Value)
             .First();
    }
