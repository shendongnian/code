    public static class HtmlExtensions
    {
        public static IHtmlString FormatMessage(this HtmlHelper htmlHelper, object message)
        {
            var result = string.Join(
                "<br/>",
                Convert
                    .ToString(message)
                    .Split(new[] { Environment.NewLine, "\r", "\n" }, StringSplitOptions.None)
                    .Select(x => htmlHelper.Encode(x))
                );
            return new HtmlString(result);
        }
    }
