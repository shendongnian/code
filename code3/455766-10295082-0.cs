    public static class Extensions {
        public static string NullIfWhiteSpace(this string value) {
            if (String.IsNullOrWhiteSpace(value)) { return null; }
            return value;
        }
    }
