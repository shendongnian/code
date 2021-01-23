    if (!String.IsNullOrEmpty(validationMessage)) {
    		builder.SetInnerText(validationMessage);
    	}
    	else if (modelError != null) {
    		builder.SetInnerText(GetUserErrorMessageOrDefault(htmlHelper.ViewContext.HttpContext, modelError, modelState));
    	}
