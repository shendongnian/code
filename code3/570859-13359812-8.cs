    public static class  MessageHelpers
    {
        public static MvcHtmlString WarningMessageFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            if (htmlHelper.ViewData.ModelState["IgnoreWarnings"] != null)
                return htmlHelper.ValidationMessageFor(expression);
            return MvcHtmlString.Empty;
        }
        public static MvcHtmlString ErrorMessageFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            if (htmlHelper.ViewData.ModelState["IgnoreWarnings"] == null)
                return htmlHelper.ValidationMessageFor(expression);
            return MvcHtmlString.Empty;
        }
    }
