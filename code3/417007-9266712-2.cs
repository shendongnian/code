    public static class StringExtensions {
        public static bool EqualsIC(this string self, string string1) {
            return self.Equals(string1, StringComparison.InvariantCultureIgnoreCase);        
        }
    }
