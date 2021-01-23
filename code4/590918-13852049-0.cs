    public struct HtmlString
    {
        public readonly string HTML;
        HtmlString(string encoded)
        {
            HTML = encoded;
        }
        public static explicit operator HtmlString(string encoded)
        {
            // Assumes string is already HTML encoded.
            return new HtmlString(encoded);
        }
        public static HtmlString Encode(string rawText)
        {
            if (rawText == null) return new HtmlString(null);
            return new HtmlString(System.Web.HttpUtility.HtmlEncode(rawText));
        }
        public static HtmlString operator +(HtmlString a, HtmlString b)
        {
            return new HtmlString(String.Concat(a.HTML, b.HTML));
        }
        public static HtmlString operator +(HtmlString a, string b)
        {
            return new HtmlString(String.Concat(a.HTML, System.Web.HttpUtility.HtmlEncode(b)));
        }
        public static HtmlString operator +(string a, HtmlString b)
        {
            return new HtmlString(String.Concat(System.Web.HttpUtility.HtmlEncode(a), b.HTML));
        }
        public static HtmlString Concat(HtmlString str0, HtmlString str1)
        {
            return new HtmlString(String.Concat(str0.HTML, str1.HTML));
        }
        public static HtmlString Concat(HtmlString str0, HtmlString str1, HtmlString str2)
        {
            return new HtmlString(String.Concat(str0.HTML, str1.HTML, str2.HTML));
        }
        public static HtmlString Concat(HtmlString str0, HtmlString str1, HtmlString str2, HtmlString str3)
        {
            return new HtmlString(String.Concat(str0.HTML, str1.HTML, str2.HTML, str3.HTML));
        }
        public static HtmlString Concat(params HtmlString[] strings)
        {
            var encodeds = new string[strings.Length];
            for (int i = 0; i < encodeds.Length; ++i)
                encodeds[i] = strings[i].HTML;
            return new HtmlString(String.Concat(encodeds));
        }
    }
