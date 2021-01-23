    private HttpActionDescriptor GetActionDescriptor()
		{
			if (controllerContext.ControllerDescriptor == null)
				GetControllerType();
			var actionSelector = new ApiControllerActionSelector();
			var results = actionSelector.GetActionMapping(controllerContext.ControllerDescriptor);
			try
			{
				return actionSelector.SelectAction(controllerContext);
			}
			catch 
			{
				var subActions = results[request.RequestUri.Segments.Last()];
				var action = subActions.FirstOrDefault(a => a.SupportedHttpMethods.First(m => m.Method == request.Method.Method) != null);
				return action;	
			}
		}
