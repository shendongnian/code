    public static class HtmlHelpers
    {
        public static IHtmlString Example<TModel, TProperty>(
            this HtmlHelper<TModel> html, 
            Expression<Func<TModel, TProperty>> ex
        )
        {
            var metadata = ModelMetadata.FromLambdaExpression(ex, html.ViewData);
            var displayName = metadata.DisplayName;
            return new HtmlString(html.Encode(displayName));
        }
    }
