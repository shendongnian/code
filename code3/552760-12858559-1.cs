    public static IHtmlString TransLabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
            {
                var metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
                var htmlFieldName = ExpressionHelper.GetExpressionText(expression);
                var modelType = typeof (TModel);
                
                var resolvedLabelText = metadata.DisplayName ?? metadata.PropertyName;
                if (String.IsNullOrEmpty(resolvedLabelText))
                    return MvcHtmlString.Empty;
                
                var labelProperty = modelType.GetProperty("labels");
                if (labelProperty != null)
                {
                    var labels = labelProperty.GetValue(html.ViewData.Model, null) as Dictionary<string, string>;
                    if (labels != null && labels.ContainsKey(resolvedLabelText))
                        resolvedLabelText = labels[resolvedLabelText];
                }
               
                var tag = new TagBuilder("label");
                tag.Attributes.Add("for", TagBuilder.CreateSanitizedId(html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(htmlFieldName)));
                tag.SetInnerText(resolvedLabelText);
                return MvcHtmlString.Create(tag.ToString());
            }
