     public static bool HasComponent<T>()
     {
        foreach (object c in components)
        {
           lock (c.GetType())
           {
               if (c is T)
               {
                  return true;
               }
           }
                        
         }
         return false;
    }
