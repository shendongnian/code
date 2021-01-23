    public static MvcHtmlString BootstrapLabelFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper,
                                                                Expression<Func<TModel, TValue>> expression)
    {
        var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
        var htmlFieldName = ExpressionHelper.GetExpressionText(expression);
        var resolvedLabelText = metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();
        if (String.IsNullOrEmpty(resolvedLabelText))
        {
            return MvcHtmlString.Empty;
        }
    
        TagBuilder tag = new TagBuilder("label");
        tag.Attributes.Add("for", TagBuilder.CreateSanitizedId(htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(htmlFieldName)));
        tag.Attributes.Add("class", "control-label");
        tag.SetInnerText(resolvedLabelText);
        return new MvcHtmlString(tag.ToString(TagRenderMode.Normal));
    }
