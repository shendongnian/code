    public static class Extension
    {
      public static string RemoveLast(this IList<string> myList)
      {
         int lastItemIndex = myList.Count - 1;
         string lastItem = myList.Last();
         myList.RemoveAt(lastItemIndex);
         return lastItem; 
      }
    }
