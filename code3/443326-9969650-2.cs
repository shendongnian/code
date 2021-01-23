      var uniqueList = myMainList
          .Concat(myAddList)
          .DistinctBy(item => item.MyGuid)
          .ToArray();
      public static IEnumerable<T> DistinctBy<T, TKey>(this IEnumerable<T> items, 
                        Func<T, TKey> keyer)
      {
        var set = new HashSet<TKey>();
        var list = new List<T>();
        foreach (var item in items)
        {
          var key = keyer(item);
          if (set.Contains(key))
            continue;
          list.Add(item);
          set.Add(key);
        }
        return list;
      }
