        public static MvcHtmlString TextBoxForChild<TModel, TProperty>(
                this HtmlHelper<TModel> htmlHelper,
                Expression<Func<TModel, TProperty>> expression,
                string parentName,
                int index,
                IDictionary<string, object> htmlAttributes)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var rules = ModelValidatorProviders.Providers.GetValidators(metadata, htmlHelper.ViewContext).SelectMany(v => v.GetClientValidationRules());
            if (htmlAttributes == null)
                htmlAttributes = new Dictionary<String, object>();
            if (!String.IsNullOrWhiteSpace(metadata.Watermark))
                htmlAttributes["placeholder"] = metadata.Watermark;
            UnobtrusiveValidationAttributesGenerator.GetValidationAttributes(rules, htmlAttributes);
            return htmlHelper.TextBox(String.Format("{0}[{1}].{2}", parentName, index, metadata.PropertyName), metadata.Model, htmlAttributes);
        }
