	public static MvcHtmlString LabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, Object htmlAttributes) {
		ModelMetadata metadata = ModelMetadata.FromLambdaExpression<TModel, TValue>(expression, html.ViewData);
		String fieldname = ExpressionHelper.GetExpressionText(expression);
		fieldname = metadata.DisplayName ?? metadata.PropertyName ?? fieldname.Split(new Char[] { '.' }).Last<String>();
		if (String.IsNullOrEmpty(fieldname)) {
			return MvcHtmlString.Empty;
		}
		TagBuilder tagBuilder = new TagBuilder("label");
		tagBuilder.Attributes.Add("for", TagBuilder.CreateSanitizedId(html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(fieldname)));
		tagBuilder.SetInnerText(fieldname);
		RouteValueDictionary attr = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
		tagBuilder.MergeAttributes<String, Object>(attr);
		return tagBuilder.ToMvcHtmlString();
	}
