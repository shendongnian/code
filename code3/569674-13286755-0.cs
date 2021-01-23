    public static class SomeUtilityClass {
        public static IEnumerable<T> Where<T>(
            this IEnumerable<T> source, Func<T,bool> predicate)
        {
            foreach(var item in source)
            {
                if(predicate(item)) yield return item;
            }
        }
        public static bool All<T>(
            this IEnumerable<T> source, Func<T,bool> predicate)
        {
            foreach(var item in source)
            {
                if(!predicate(item)) return false;
            }
            return true;
        }
    }
