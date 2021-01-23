    public static class Extensions
    {
       static IEnumerable<T> Leave<T>(this IEnumerable<T> items, int numToSkip)
       {
          var list = items.ToList();
          // Assert numToSkip <= list count.
          list.RemoveRange(list.Count - numToSkip, numToSkip);
          return List
       }
    }
    
    
    string alphabet = "abcdefghijklmnopqrstuvwxyz";
    var chars = alphabet.Leave(10); // abcdefghijklmnop
