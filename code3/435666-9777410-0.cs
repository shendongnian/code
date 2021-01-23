    public static IHtmlString RenderList<TModel, TItem>(
        this HtmlHelper<TModel> html, 
        Expression<Func<TModel, IEnumerable<TItem>>> dataExpression
    )
    {
        var parentEx = ((MemberExpression)dataExpression.Body).Expression;
        var lambda = Expression.Lambda<Func<TModel, object>>(parentEx, dataExpression.Parameters[0]);
        var value = ModelMetadata.FromLambdaExpression(lambda, html.ViewData).Model;
        ...
    }
