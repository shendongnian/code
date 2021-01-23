    static class MyOwnHtmlHelpers
    {
        public static string EmptyIfNull<TModel>(this HtmlHelper<TModel> helper, Func<TModel, string> accessor)
        {
            try
            {
                var result = accessor.Invoke(helper.ViewData.Model);
                return result;
            }
            catch(NullReferenceException)
            {
                return string.Empty;
            }
        }
    }
