    public class AntiXssAttribute : ActionFilterAttribute
    {
        public override Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            if (actionContext.ActionArguments != null && actionContext.ActionArguments.Any())
            {
                var arguments = actionContext.ActionArguments;
                foreach (var argument in arguments)
                {
                    var properties = argument.Value.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
                        .Where(prop => prop.CanRead && prop.CanWrite && prop.PropertyType == typeof(string) &&
                                       prop.GetGetMethod(true).IsPublic && prop.GetSetMethod(true).IsPublic);
                    foreach (var propertyInfo in properties)
                    {
                        if (propertyInfo.GetValue(argument.Value) is string stringValue)
                        {
                            var encodedString = AntiXssEncoder.HtmlEncode(stringValue, true);
                            if (encodedString != stringValue)
                            {
                                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Forbidden, "Forbidden input. The following characters are not allowed: &, <, >, \", '");
                                return Task.CompletedTask;
                            }
                        }
                    }
                }
            }
            return base.OnActionExecutingAsync(actionContext, cancellationToken);
        }
    }
