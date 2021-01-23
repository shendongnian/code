    static void Main(string[] args)
        {
            string text = "The max length is seven";
            text = RemoveChars(text, 7);
        }
        private static string RemoveChars(string text, int length)
        {
            if (!String.IsNullOrEmpty(text) && text.Length > length)
                text = text.Remove(length, text.Length - length);
            return text;
        }
