    private async Task ExecuteBindingAsyncCore(ModelMetadataProvider metadataProvider, HttpActionContext actionContext,
            HttpParameterDescriptor paramFromBody, Type type, HttpRequestMessage request, IFormatterLogger formatterLogger,
            CancellationToken cancellationToken)
    {
        var model = await ReadContentAsync(request, type, Formatters, formatterLogger, cancellationToken);
        if(model == null) model = Activator.CreateInstance(type);
        var routeDataValues = actionContext.ControllerContext.RouteData.Values;
        var routeParams = routeDataValues.Except(routeDataValues.Where(v => v.Key == "controller"));
        var queryStringParams = new Dictionary<string, object>(QueryStringValues(request));
        var allUriParams = routeParams.Union(queryStringParams).ToDictionary(pair => pair.Key, pair => pair.Value);
        foreach(var key in allUriParams.Keys) {
            var prop = type.GetProperty(key, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
            if(prop == null) {
                continue;
            }
            var descriptor = TypeDescriptor.GetConverter(prop.PropertyType);
            if(descriptor.CanConvertFrom(typeof(string))) {
                prop.SetValue(model, descriptor.ConvertFromString(allUriParams[key] as string));
            }
        }
        // Set the merged model in the context
        SetValue(actionContext, model);
        if(BodyModelValidator != null) {
            BodyModelValidator.Validate(model, type, metadataProvider, actionContext, paramFromBody.ParameterName);
        }
    }
    private static IDictionary<string, object> QueryStringValues(HttpRequestMessage request)
    {
        var queryString = string.Join(string.Empty, request.RequestUri.ToString().Split('?').Skip(1));
        var queryStringValues = System.Web.HttpUtility.ParseQueryString(queryString);
        return queryStringValues.Cast<string>().ToDictionary(x => x, x => (object)queryStringValues[x]);
    }
