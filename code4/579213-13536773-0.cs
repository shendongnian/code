    public static MvcHtmlString DaisyTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<string,object> attributes = null)
        {
            var value = ((PropertyViewModelProperty)htmlHelper.ViewData.Model.GetType().GetProperty(ExpressionHelper.GetExpressionText(expression)).GetValue(htmlHelper.ViewData.Model, null)).Value;
            return MvcHtmlString.Create(String.Format("<input name=\"{0}\" value=\"{1}\" class=\"{2}\" />", CreateForInputName(typeof(TModel), htmlHelper), value, attributes["class"]));
        }
