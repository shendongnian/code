    public static Dictionary<int, List<T>> ToGroupedDictionary<T>
       (this IList<T> pList, int pGroupSize)
    {
       var dict = new Dictionary<int, List<T>>();
         
       int x = 0;
       while (x < pList.Count)
       {
          var newList = new List<T>();
          for (int y = 0; y < pGroupSize && x < pList.Count; y++, x++)
             newList.Add(pList[x]);
  
          dict.Add(dict.Count, newList);
       }
       return dict;
    }
