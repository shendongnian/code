    public static MvcHtmlString MultiSelectFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
    {
    /*The challenge I faced here was that the expression you passed could very well be nested, so in order overcome this, I decompiled the dll to see how MVC does it, and I found this piece of code.*/
    
     string expressionText = System.Web.Mvc.ExpressionHelper.GetExpressionText((LambdaExpression)expression);
     System.Web.Mvc.ModelMetadata metadata = System.Web.Mvc.ModelMetadata.FromStringExpression(expressionText, htmlHelper.ViewData);
    }
