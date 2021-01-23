        public static string RemoveStyle(string html, string style)
        {
            Regex regex = new Regex(style + "\\s*:.*?;?");
            return regex.Replace(html, string.Empty);
        }
