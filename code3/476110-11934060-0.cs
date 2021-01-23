            public static MvcHtmlString TextBoxWithCustomHtmlAttributesFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
            {
                Type propertyType = typeof(TProperty);
                Type undelyingNullableType = Nullable.GetUnderlyingType(propertyType);
                var metadata = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
                string prefix = ExpressionHelper.GetExpressionText(expression);
                var validationAttributes = helper.GetUnobtrusiveValidationAttributes(prefix, metadata);
                
                string pType = (undelyingNullableType ?? propertyType).Name.ToString().ToLower();
                if (htmlAttributes != null)
                {
                    var dataTypeDict = new Dictionary<string, object>(); 
                    dataTypeDict.Add("data-type", pType);
                    if (validationAttributes != null && validationAttributes.Count > 0)
                    {
                        foreach (var i in validationAttributes)
                        {
                            dataTypeDict.Add(i.Key, i.Value);
                        }
                    }
                    htmlAttributes = Combine(new RouteValueDictionary(htmlAttributes), new RouteValueDictionary(dataTypeDict));
                }
                var textBox = helper.TextBoxFor(expression, (Dictionary<string, object>)htmlAttributes);
                return textBox;
            }
