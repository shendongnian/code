    public static class HtmlHelpers
    {
        public static IHtmlString Example<TModel, TProperty>(
            this HtmlHelper<TModel> html, 
            Expression<Func<TModel, TProperty>> ex
        )
        {
            var metadata = ModelMetadata.FromLambdaExpression(ex, html.ViewData);
            if (metadata.AdditionalValues.ContainsKey("foo"))
            {
                var foo = metadata.AdditionalValues["foo"] as string;
                return new HtmlString(html.Encode(foo));
            }
            return MvcHtmlString.Empty;
        }
    }
