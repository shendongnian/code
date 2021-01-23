       public static void Retion<T>() where T : IDisposable, new()
       { 
 
                using (T entitiesContext = new T()) 
                    {...} 
       }
