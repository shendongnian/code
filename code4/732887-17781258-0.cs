        public static class Couter
        {
        
               private static long hit;
               public static void HitCounter()
               {
                  hit++;
               }
               public static long GetCounter()
               {
                  return hit;
               }
        }
