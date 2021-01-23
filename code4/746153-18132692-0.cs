       public static class ListOfListExtention {
            public static bool ContainAny( this List<List<int>> lists, int number ) {
                 return lists.Any(l=>l.Any(x=>x == number))
            }
       }
