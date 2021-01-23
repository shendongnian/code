    public static Dictionary<int, List<T>> ToGroupedDictionary<T>
       (this ICollection<T> pCollection, int pGroupSize)
    {
       var dict = new Dictionary<int, List<T>>();
         
       int x = 0;
       while (x < pCollection.Count)
       {
          var newList = new List<T>();
          for (int y = 0; y < pGroupSize, x < pCollection.Count; y++, x++)
             newList.Add(pCollection[x]);
  
          dict.Add(dict.Count, newList);
       }
       return dict;
    }
