    public static IHtmlString AutocompleteUrlFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string url)
    {
        if (string.IsNullOrEmpty(url))
            throw new ArgumentException("url");
        var property = ModelMetadata.FromLambdaExpression(expression, html.ViewData).PropertyName;
        AutocompleteAttribute.Urls[property] = url;
        return MvcHtmlString.Empty;
    }
