	[AttributeUsage (AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
	public sealed class ValidateModelAttribute : ActionFilterAttribute
	{
		private static readonly ConcurrentDictionary<HttpActionDescriptor, IList<string>> NotNullParameterNames =
			new ConcurrentDictionary<HttpActionDescriptor, IList<string>> ();
		/// <summary>
		/// Occurs before the action method is invoked.
		/// </summary>
		/// <param name="actionContext">The action context.</param>
		public override void OnActionExecuting (HttpActionContext actionContext)
		{
			var not_null_parameter_names = GetNotNullParameterNames (actionContext);
			foreach (var not_null_parameter_name in not_null_parameter_names)
			{
				object value;
				if (!actionContext.ActionArguments.TryGetValue (not_null_parameter_name, out value) || value == null)
					actionContext.ModelState.AddModelError (not_null_parameter_name, "Parameter \"" + not_null_parameter_name + "\" was not specified.");
			}
			if (actionContext.ModelState.IsValid == false)
				actionContext.Response = actionContext.Request.CreateErrorResponse (HttpStatusCode.BadRequest, actionContext.ModelState);
		}
		private static IList<string> GetNotNullParameterNames (HttpActionContext actionContext)
		{
			var result = NotNullParameterNames.GetOrAdd (actionContext.ActionDescriptor,
			                                             descriptor => descriptor.GetParameters ()
			                                                                     .Where (p => !p.IsOptional && p.DefaultValue == null &&
			                                                                                  !p.ParameterType.IsValueType &&
			                                                                                  p.ParameterType != typeof (string))
			                                                                     .Select (p => p.ParameterName)
			                                                                     .ToList ());
			return result;
		}
	}
