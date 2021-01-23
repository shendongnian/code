        public static string FormatWith(this string text, params object[] args)
        {
            return string.Format(text, args);
        }
        public static string ReadFully(this Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
