    static class Utilities{
        public static bool ContainsDistinctElements(this IEnumerable<string> a, IEnumerable<string> b){
            var res = a.Except(b);
            if(res == null)
               return false;
        
            return true;
        }
    }
