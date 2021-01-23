    public class ArrayInputAttribute : ActionFilterAttribute
    {
        private readonly string _ParameterName;
        /// <summary>
        /// 
        /// </summary>
        public string Separator { get; set; }
        /// <summary>
        /// cons
        /// </summary>
        /// <param name="parameterName"></param>
        public ArrayInputAttribute(string parameterName)
        {
            _ParameterName = parameterName;
            Separator = ",";
        }
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.ActionArguments.ContainsKey(_ParameterName))
            {
                var parameterDescriptor = actionContext.ActionDescriptor.GetParameters().FirstOrDefault(p => p.ParameterName == _ParameterName);
                if (parameterDescriptor != null && parameterDescriptor.ParameterType.IsArray)
                {
                    var type = parameterDescriptor.ParameterType.GetElementType();
                    var parameters = String.Empty;
                    if (actionContext.ControllerContext.RouteData.Values.ContainsKey(_ParameterName))
                    {
                        parameters = (string)actionContext.ControllerContext.RouteData.Values[_ParameterName];
                    }
                    else
                    {
                        var queryString = actionContext.ControllerContext.Request.RequestUri.ParseQueryString();
                        if (queryString[_ParameterName] != null)
                        {
                            parameters = queryString[_ParameterName];
                        }
                    }
                    var values = parameters.Split(new[] { Separator }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(TypeDescriptor.GetConverter(type).ConvertFromString).ToArray();
                    var typedValues = Array.CreateInstance(type, values.Length);
                    values.CopyTo(typedValues, 0);
                    actionContext.ActionArguments[_ParameterName] = typedValues;
                }
            }
        }
    }
