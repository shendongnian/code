    static class Utility
    {
         public static void InsertElement(this List<int> list, int n)
         {
             if(!list.Contains(n))
             {     
                 for(int i = 0; i < list.Count; i++)
                 {
                      if(list[i] > n)
                      {
                         list.Insert(i-1, n);
                         break;
                      }
                      if(i == list.Count - 1)
                         list.Add(n);
                 }
             }
         }
    }
