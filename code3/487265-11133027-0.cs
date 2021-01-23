    public static MvcHtmlString FieldForAmount<TModel, TValue>(
        this HtmlHelper<TModel> htmlHelper,
        Expression<Func<TModel, TValue>> expression
    )
    {
        var htmlAttributes = new Dictionary<string, object>
        {
            { "readonly", "readonly" },
            { "class", "lockedField amountField" },
        };
        var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
        var value = string.Format(Formats.AmountFormat, metadata.Model);
        var name = ExpressionHelper.GetExpressionText(expression);
        var fullHtmlFieldName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
        return htmlHelper.TextBox(fullHtmlFieldName, value, htmlAttributes);
    }
