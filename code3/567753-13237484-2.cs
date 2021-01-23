    static void Main(string[] args)
        {
            string text = "The max length is seven".RemoveChars(7);
        }
        public static string RemoveChars(this string text, int length)
        {
            if (!String.IsNullOrEmpty(text) && text.Length > length)
                text = text.Remove(length, text.Length - length);
            return text;
        }
