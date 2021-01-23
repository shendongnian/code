	protected override void OnActionExecuting(ActionExecutingContext filterContext) {
		base.OnActionExecuting(filterContext);
			
		// Unfortunately it seems this is the only way to get the Model object
		if( filterContext.ActionParameters.ContainsKey("model") ) {
				
			Object                    model = filterContext.ActionParameters["model"];
			ModelStateDictionary modelState = filterContext.Controller.ViewData.ModelState; // ViewData.Model always returns null at this point.
				
			ICustomValidation modelValidation = model as ICustomValidation;
			if( modelValidation != null ) {
				modelValidation.PerformValidation( modelState );
			}
		}
		
	}
