    public static MvcHtmlString PhoneNumberFor<TModel>(this HtmlHelper<TModel> helper, Expression<Func<TModel, string>> expression, object htmlAttributes)
        {
            var value = ModelMetadata.FromLambdaExpression(expression, helper.ViewData).Model as string;
    
            if (!string.IsNullOrEmpty(value) && value.Length == 10)
            {
                string phoneNumber = value.ToString();
    			string areaCode = phoneNumber.SubString(0,3);
    			string phonePrefix = phoneNumber.SubString(3,3);
    			string phoneSuffix = phoneNumber.SubString(6);
    			var formattedStr = string.Format("({0}){1}-{2}", areaCode, phonePrefix, phoneSuffix);                
                var fieldName = helper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(ExpressionHelper.GetExpressionText(expression));
                helper.ViewData[fieldName] = formattedStr;
    
            }
    
            return helper.TextBoxFor(expression, htmlAttributes);           
        }
