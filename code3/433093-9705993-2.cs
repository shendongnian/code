    public static class StringExtensions
    {
        public static string ToMaskedString(this String value)
        {
            var pattern = "^(/d{3})(/d{3})(/d*)$";
            var regExp = new Regex(pattern);
            return regExp.Replace(value, "$1-$2-$3");
        }
    }
