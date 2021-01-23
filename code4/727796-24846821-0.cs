    public class BodyAndUriParameterBinding : HttpParameterBinding
    {
        private IEnumerable<MediaTypeFormatter> Formatters { get; set; }
        private IBodyModelValidator BodyModelValidator { get; set; }
        public BodyAndUriParameterBinding(HttpParameterDescriptor descriptor)
            : base (descriptor)
        {
            var httpConfiguration = descriptor.Configuration;
            Formatters = httpConfiguration.Formatters;
            BodyModelValidator = httpConfiguration.Services.GetBodyModelValidator();
        }
        private Task<object> ReadContentAsync(HttpRequestMessage request, Type type,
            IEnumerable<MediaTypeFormatter> formatters, IFormatterLogger formatterLogger, CancellationToken cancellationToken)
        {
            var content = request.Content;
            if (content == null)
            {
                var defaultValue = MediaTypeFormatter.GetDefaultValueForType(type);
                return defaultValue == null ? Task.FromResult<object>(null) : Task.FromResult(defaultValue);
            }
            return content.ReadAsAsync(type, formatters, formatterLogger, cancellationToken);
        }
        public override Task ExecuteBindingAsync(ModelMetadataProvider metadataProvider, HttpActionContext actionContext,
            CancellationToken cancellationToken)
        {
            var paramFromBody = Descriptor;
            var type = paramFromBody.ParameterType;
            var request = actionContext.ControllerContext.Request;
            var formatterLogger = new ModelStateFormatterLogger(actionContext.ModelState, paramFromBody.ParameterName);
            return ExecuteBindingAsyncCore(metadataProvider, actionContext, paramFromBody, type, request, formatterLogger, cancellationToken);
        }
        // Perf-sensitive - keeping the async method as small as possible
        private async Task ExecuteBindingAsyncCore(ModelMetadataProvider metadataProvider, HttpActionContext actionContext,
            HttpParameterDescriptor paramFromBody, Type type, HttpRequestMessage request, IFormatterLogger formatterLogger,
            CancellationToken cancellationToken)
        {
            var model = await ReadContentAsync(request, type, Formatters, formatterLogger, cancellationToken);
            if (model != null)
            {
                var routeParams = actionContext.ControllerContext.RouteData.Values;
                foreach (var key in routeParams.Keys.Where(k => k != "controller"))
                {
                    var prop = type.GetProperty(key, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
                    if (prop == null)
                    {
                        continue;
                    }
                    var descriptor = TypeDescriptor.GetConverter(prop.PropertyType);
                    if (descriptor.CanConvertFrom(typeof(string)))
                    {
                        prop.SetValue(model, descriptor.ConvertFromString(routeParams[key] as string));
                    }
                }
            }
            // Set the merged model in the context
            SetValue(actionContext, model);
            if (BodyModelValidator != null)
            {
                BodyModelValidator.Validate(model, type, metadataProvider, actionContext, paramFromBody.ParameterName);
            }
        }
    }
