    public static class InputExtensions
    {
        public static MvcHtmlString CheckBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object value)
        {
            return htmlHelper.CheckBoxFor<TModel, TProperty>(expression, value, null);
        }
    
        public static MvcHtmlString CheckBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object value, object htmlAttributes)
        {
            return htmlHelper.CheckBoxFor<TModel, TProperty>(expression, value, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }
    
        public static MvcHtmlString CheckBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object value, IDictionary<string, object> htmlAttributes)
        {
            ModelMetadata modelMetadata = ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression, htmlHelper.ViewData);
            return CheckBoxHelper<TModel, TProperty>(htmlHelper, modelMetadata, modelMetadata.Model, ExpressionHelper.GetExpressionText(expression), value, htmlAttributes);
        }
    
        private static MvcHtmlString CheckBoxHelper<TModel, TProperty>(HtmlHelper htmlHelper, ModelMetadata metadata, object model, string name, object value, IDictionary<string, object> htmlAttributes)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
    
            RouteValueDictionary routeValueDictionary = htmlAttributes != null ? new RouteValueDictionary(htmlAttributes) : new RouteValueDictionary();
    
            string fullHtmlFieldName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
    
            if (string.IsNullOrEmpty(fullHtmlFieldName))
            {
                throw new ArgumentException("Le nom du control doit être fourni", "name");
            }
    
            TagBuilder tagBuilder = new TagBuilder("input");
    
            tagBuilder.MergeAttributes<string, object>(htmlAttributes);
            tagBuilder.MergeAttribute("type", HtmlHelper.GetInputTypeString(InputType.CheckBox));
            tagBuilder.MergeAttribute("name", fullHtmlFieldName, true);
    
            string text = Convert.ToString(value, CultureInfo.CurrentCulture);
    
            tagBuilder.MergeAttribute("value", text);
    
            if (metadata.Model != null)
            {
                foreach (var item in metadata.Model as System.Collections.IEnumerable)
                {
                    if (Convert.ToString(item, CultureInfo.CurrentCulture).Equals(text))
                    {
                        tagBuilder.Attributes.Add("checked", "checked");
                        break;
                    }
                }
            }
    
            return MvcHtmlString.Create(tagBuilder.ToString(TagRenderMode.SelfClosing));
        }
    }
