    public static class HtmlExtensions
    {
        private readonly static Regex _wordsRegex = new Regex(@"\s", RegexOptions.Compiled);
        public static IHtmlString FormatMessage(this HtmlHelper htmlHelper, string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return new HtmlString(string.Empty);
            }
            if (message.Length < 20)
            {
                return new HtmlString(htmlHelper.Encode(message));
            }
            var result = string.Join(" ", _wordsRegex.Split(message).Take(2));
            return new HtmlString(result + " ...");
        }
    }
