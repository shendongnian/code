    public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> enumerable) {
      foreach (var cur in enumerable) {
        collection.Add(cur);
      }
    }
    myList2.AddRange(myList1);
