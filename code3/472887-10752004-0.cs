    public static class HtmlExtensions
    {
        public static IHtmlString DislpayFormattedFor<TModel>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, string>> expression
        )
        {
            var value = Convert.ToString(
                ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData).Model
            );
            if (string.IsNullOrEmpty(value))
            {
                return MvcHtmlString.Empty;
            }
            value = string.Join(
                "<br/>",
                value.Split(
                    new[] { Environment.NewLine }, 
                    StringSplitOptions.None
                ).Select(HttpUtility.HtmlEncode)
            );
            return new HtmlString(value);
        }
    }
