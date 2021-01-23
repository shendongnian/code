        public  static MvcHtmlString ValidationMessageFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, bool addRequiredFieldMark)
        {
            return ValidationMessageFor(htmlHelper, expression, null /* validationMessage */, new RouteValueDictionary(), addRequiredFieldMark: addRequiredFieldMark);
        }
        public static MvcHtmlString ValidationMessageFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string validationMessage, IDictionary<string, object> htmlAttributes, bool? addRequiredFieldMark=false)
        {
            return ValidationMessageHelper(htmlHelper,
                                           ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData),
                                           ExpressionHelper.GetExpressionText(expression),
                                           validationMessage,
                                           htmlAttributes,
                                           addRequiredFieldMark:addRequiredFieldMark);
        }
        private static MvcHtmlString ValidationMessageHelper(this HtmlHelper htmlHelper, ModelMetadata modelMetadata, string expression, string validationMessage, IDictionary<string, object> htmlAttributes, bool? addRequiredFieldMark = false)
        {
            string modelName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(expression);
            
            //Changed (http://stackoverflow.com/questions/8380988/how-to-customize-html-validationmessagefor-in-asp-mvc).
            //FormContext formContext = htmlHelper.ViewContext.GetFormContextForClientValidation();
            FormContext formContext = htmlHelper.ViewContext.ClientValidationEnabled ? htmlHelper.ViewContext.FormContext : null;
            if (!htmlHelper.ViewData.ModelState.ContainsKey(modelName) && formContext == null)
            {
                return null;
            }
            ModelState modelState = htmlHelper.ViewData.ModelState[modelName];
            ModelErrorCollection modelErrors = (modelState == null) ? null : modelState.Errors;
            ModelError modelError = (((modelErrors == null) || (modelErrors.Count == 0)) ? null : modelErrors.FirstOrDefault(m => !String.IsNullOrEmpty(m.ErrorMessage)) ?? modelErrors[0]);
            if (modelError == null && formContext == null)
            {
                return null;
            }
            TagBuilder builder = new TagBuilder("span");
            builder.MergeAttributes(htmlAttributes);
            builder.AddCssClass((modelError != null) ? HtmlHelper.ValidationMessageCssClassName : HtmlHelper.ValidationMessageValidCssClassName);
            if (!String.IsNullOrEmpty(validationMessage))
            {
                builder.SetInnerText(validationMessage);
            }
            else if (modelError != null)
            {
                builder.SetInnerText(GetUserErrorMessageOrDefault(htmlHelper.ViewContext.HttpContext, modelError, modelState));
            }
            if (formContext != null)
            {
                bool replaceValidationMessageContents = String.IsNullOrEmpty(validationMessage);
                // 4net toevoeging, bij required fields extra class toevoegen.
                if (modelMetadata != null && modelMetadata.IsRequired && addRequiredFieldMark.HasValue && addRequiredFieldMark.Value)
                    builder.SetInnerText("*");
                if (htmlHelper.ViewContext.UnobtrusiveJavaScriptEnabled)
                {
                    builder.MergeAttribute("data-valmsg-for", modelName);
                    builder.MergeAttribute("data-valmsg-replace", replaceValidationMessageContents.ToString().ToLowerInvariant());
                }
                else
                {
                    FieldValidationMetadata fieldMetadata = ApplyFieldValidationMetadata(htmlHelper, modelMetadata, modelName);
                    // rules will already have been written to the metadata object
                    fieldMetadata.ReplaceValidationMessageContents = replaceValidationMessageContents; // only replace contents if no explicit message was specified
                    // client validation always requires an ID
                    builder.GenerateId(modelName + "_validationMessage");
                    fieldMetadata.ValidationMessageId = builder.Attributes["id"];
                }
            }
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.Normal));
        }
