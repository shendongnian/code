    public static class HtmlHelperExtensions
    {
      
        public static MvcHtmlString LabelForCustom<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            string customDisplayName = null;
   
           var value = expression.Compile().Invoke(html.ViewData.Model);
           if (value != null)
           {
              var attribute = value.GetType().GetCustomAttributes(typeof(DisplayNameAttribute), false)
               .Cast<DisplayNameAttribute>()
               .FirstOrDefault();
               customDisplayName = attribute != null ? attribute.DisplayName : null;
           }
        
             string htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            string labelText = metadata.DisplayName ?? customDisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();
            if (String.IsNullOrEmpty(labelText))
            {
                return MvcHtmlString.Empty;
            }
            TagBuilder tag = new TagBuilder("label");
             tag.Attributes.Add("for", html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName));
            tag.SetInnerText(labelText);
            return MvcHtmlString.Create(tag.ToString(TagRenderMode.Normal));
        }
    }
