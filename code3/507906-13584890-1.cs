        private static string GetPropertyDisplayNameFromLambdaExpression<TModel, TValue>(HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            string htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            return metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last() ?? "Geen tekst";
        }
        private static string GetPropertyValueFromLambdaExpression<TModel, TValue>(HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            string value = string.Empty;
            TModel model = html.ViewData.Model;
            if (model != null)
            {
                var expr = expression.Compile().Invoke(model);
                if (expr != null)
                {
                    value = expr.ToString();
                }
            }
            return value;
        }
        private static string GetPropertyNameFromLambdaExpression<TModel, TValue>(HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            return metadata.PropertyName;
        }
        private static IDictionary<string, object> GetPropertyValidationAttributes<TModel, TValue>(HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, IDictionary<string, object> htmlAttributes)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            IDictionary<string, object> validationAttributes = html.GetUnobtrusiveValidationAttributes(ExpressionHelper.GetExpressionText(expression), metadata);
            if (htmlAttributes == null)
            {
                htmlAttributes = validationAttributes;
            }
            else
            {
                htmlAttributes = htmlAttributes.Concat(validationAttributes).ToDictionary(k => k.Key, v => v.Value);
            }
            return htmlAttributes;
        }
