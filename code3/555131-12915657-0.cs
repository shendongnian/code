        public static string RemoveStyle(string html, string style)
        {
            Regex regex = new Regex(style.Replace("-", "\\-") + "\\s*:.*?;");
            return regex.Replace(html, string.Empty);
        }
