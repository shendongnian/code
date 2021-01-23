       public static class ListOfListExtention {
            public static bool ContainAny<T>
               (this List<List<int>> lists, int value ) where T : IComparable<T> {
                 return lists.Any(l=>l.Any(x=>x == value))
            }
       }
 
