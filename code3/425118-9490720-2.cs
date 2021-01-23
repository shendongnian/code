    public static class HtmlExtensions
    {
        private readonly static Regex _wordsRegex = new Regex(
            @"\s", RegexOptions.Compiled
        );
        public static IHtmlString FormatMessage(
            this HtmlHelper htmlHelper, 
            string message, 
            int count = 20
        )
        {
            if (string.IsNullOrEmpty(message))
            {
                return new HtmlString(string.Empty);
            }
            var words = _wordsRegex.Split(message);
            if (words.Length < count)
            {
                return new HtmlString(htmlHelper.Encode(message));
            }
            var result = string.Join(
                " ", 
                words.Select(w => htmlHelper.Encode(w)).Take(count)
            );
            return new HtmlString(result + " ...");
        }
    }
