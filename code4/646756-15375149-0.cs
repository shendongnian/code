        public static string StripStart(this string text, string value, bool ignoreCase = false)
        {
            // if(text.EndsWith...
            if (text.StartsWith(value, ignoreCase, CultureInfo.InvariantCulture))
                return text.Substring(value.Length);
            return text;
        }
