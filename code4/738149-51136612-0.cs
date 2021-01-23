    using System;
    using System.Collections.Concurrent;
    using System.ComponentModel.DataAnnotations;
    using System.Net;
    using System.Net.Http;
    using System.Reflection;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;
    
    namespace your_base_namespace.Web.Http.Filters
    {
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true)]
        public class ValidateModelStateAttribute : ActionFilterAttribute
        {
            private delegate void ValidateHandler(HttpActionContext actionContext);
    
            private static readonly ConcurrentDictionary<HttpActionBinding, ValidateHandler> _validateActionByActionBinding;
    
            static ValidateModelStateAttribute()
            {
                _validateActionByActionBinding = new ConcurrentDictionary<HttpActionBinding, ValidateHandler>();
            }
    
            public override void OnActionExecuting(HttpActionContext actionContext)
            {
                GetValidateHandler(actionContext.ActionDescriptor.ActionBinding)(actionContext);
    
                if (actionContext.ModelState.IsValid)
                    return;
    
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, actionContext.ModelState);
            }
    
            private ValidateHandler GetValidateHandler(HttpActionBinding actionBinding)
            {
                ValidateHandler validateAction;
    
                if (!_validateActionByActionBinding.TryGetValue(actionBinding, out validateAction))
                    _validateActionByActionBinding.TryAdd(actionBinding, validateAction = CreateValidateHandler(actionBinding));
    
                return validateAction;
            }
    
            private ValidateHandler CreateValidateHandler(HttpActionBinding actionBinding)
            {
                ValidateHandler handler = new ValidateHandler(c => { });
    
                var parameters = actionBinding.ParameterBindings;
    
                for (int i = 0; i < parameters.Length; i++)
                {
                    var parameterDescriptor = (ReflectedHttpParameterDescriptor)parameters[i].Descriptor;
                    var attribute = parameterDescriptor.ParameterInfo.GetCustomAttribute<RequiredAttribute>(true);
    
                    if (attribute != null)
                        handler += CreateValidateHandler(attribute, parameterDescriptor.ParameterName);
                }
    
                return handler;
            }
    
            private static ValidateHandler CreateValidateHandler(ValidationAttribute attribute, string name)
            {            
                return CreateValidateHandler(attribute, new ValidationContext(new object()) { MemberName = name });
            }
    
            private static ValidateHandler CreateValidateHandler(ValidationAttribute attribute, ValidationContext context)
            {
                return new ValidateHandler(actionContext =>
                {
                    object value;
                    actionContext.ActionArguments.TryGetValue(context.MemberName, out value);
    
                    var validationResult = attribute.GetValidationResult(value, context);
                    if (validationResult != null)
                        actionContext.ModelState.AddModelError(context.MemberName, validationResult.ErrorMessage);
                });
            }
        }
    }
