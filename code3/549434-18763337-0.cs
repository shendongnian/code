    public static MvcHtmlString HasErrorClassFor<TModel, TProperty>(
        this HtmlHelper<TModel> htmlHelper,
        Expression<Func<TModel, TProperty>> expression)
    {
        string expressionText = ExpressionHelper.GetExpressionText(expression);
        string htmlFieldPrefix = htmlHelper.ViewData.TemplateInfo.HtmlFieldPrefix;
        string fullyQualifiedName;
        if (htmlFieldPrefix.Length > 0)
        {
            fullyQualifiedName = string.Join(".", htmlFieldPrefix, expressionText);
        }
        else
        {
            fullyQualifiedName = expressionText;
        }
        bool isValid = htmlHelper.ViewData.ModelState.IsValidField(fullyQualifiedName);
        if (!isValid)
        {
            return MvcHtmlString.Create("has-error");
        }
        return MvcHtmlString.Empty;
    }
