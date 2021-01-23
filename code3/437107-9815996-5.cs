    namespace System {
    public static class StringExtensions {
        public static bool ContainsLike(this string input, string value) {
            if (string.IsNullOrWhiteSpace(input) || string.IsNullOrWhiteSpace(value)) return false;
            input = input.ToLower().RemoveDiacritics();
            value = value.ToLower().RemoveDiacritics();
            if (string.IsNullOrWhiteSpace(input) || string.IsNullOrWhiteSpace(value)) return false;
            return input.Contains(value);
        }
        public static string RemoveDiacritics(this string input) {
            return input == null ? null :      
                            Encoding.ASCII.GetString(Encoding.GetEncoding(1251).GetBytes(input));
        }
    }
    }
