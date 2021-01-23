    public static MvcHtmlString SimpleLabelFor<TModel, TValue>(
    	this HtmlHelper<TModel> html,
    	Expression<Func<TModel, TValue>> expression
    ) {
      var metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
      string htmlFieldName = ExpressionHelper.GetExpressionText(expression);
      string resolvedLabelText = metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();
      if (String.IsNullOrEmpty(resolvedLabelText)) 
                return MvcHtmlString.Empty;
            
      return MvcHtmlString.Create(resolvedLabelText);
    
    }
