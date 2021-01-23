    public static class HtmlHelpers
    {
        public static MvcHtmlString CustomDisplayFor(this HtmlHelper<Person> htmlHelper, Expression<Func<Person, string>> expression)
        {
              var customBuildString = string.Empty;
              //Make your custom implementation here
              return MvcHtmlString.Create(customBuildString);
        }
    }
