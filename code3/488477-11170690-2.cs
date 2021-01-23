    public static class Extensions {
        public static bool IsNullOrEmpty(this string obj) {
            return obj != null && obj.Length > 0;
        }
    }
    ...
            string s = null;
            bool empty = s.IsNullOrEmpty();    // Fine
