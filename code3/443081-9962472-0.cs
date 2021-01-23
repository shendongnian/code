    public static class StringExtensions {
        public static bool IsInt(this string s) {
            int i;  return Int.TryParse(s, out i);
        }
    }
