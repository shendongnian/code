    public class ArrayInputAttribute : ActionFilterAttribute
    {
        private readonly string _ParameterName;
        private readonly Type _Type;
        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(",")]
        public string Separator { get; set; }
        /// <summary>
        /// cons
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="type"></param>
        public ArrayInputAttribute(string parameterName, Type type)
        {
            _ParameterName = parameterName;
            _Type = type;
        }
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.ActionArguments.ContainsKey(_ParameterName))
            {
                var parameters = string.Empty;
                if (actionContext.ControllerContext.RouteData.Values.ContainsKey(_ParameterName))
                {
                    parameters = (string)actionContext.ControllerContext.RouteData.Values[_ParameterName];
                }
                else if (actionContext.ControllerContext.Request.RequestUri.ParseQueryString()[_ParameterName] != null)
                {
                    parameters = actionContext.ControllerContext.Request.RequestUri.ParseQueryString()[_ParameterName];
                }
                var values = parameters.Split(new[] { Separator }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(TypeDescriptor.GetConverter(_Type).ConvertFromString).ToArray();
                var typedValues = Array.CreateInstance(_Type, values.Length);
                values.CopyTo(typedValues, 0);
                actionContext.ActionArguments[_ParameterName] = typedValues;
            }
        }
    }
