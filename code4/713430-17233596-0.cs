     public static IEnumerable<T> Shadow<T>(this IEnumerable<T> items)
     {
         if (items == null)
            throw new NullReferenceException("Items cannot be null");
         List<T> list = new List<T>();
         foreach (var item in items)
         {
             list.Add(item);
         }
         return list;
     }
