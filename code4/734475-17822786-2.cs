    public static class HttpResponseMessageUtils
    {
       /// <summary>
       ///     Registers api controller actions which return HttpResponseMessage
       ///     and include the ResponseType attribute to be populated with web api
       ///     auto generated help.
       /// </summary>
       /// <param name="assembly">The assembly to search for</param>
       public static void RegisterHelpResponseTypes(Assembly assembly)
       {
           var apiControllerTypes = assembly.GetTypes().Where(typeof(ApiController).IsAssignableFrom);
    
           foreach (var apiControllerType in apiControllerTypes)
           {
               // Actions with ResponseTypeAttribute and that return HttpResponseMessage
               var validActions = apiControllerType.GetMethods()
                                                   .Where(method =>
                                                       Attribute.IsDefined(method, typeof(ResponseTypeAttribute))
                                                       &&
                                                       (method.ReturnType == typeof(HttpResponseMessage)));
    
               foreach (var action in validActions)
               {
                   var responseType = (ResponseTypeAttribute)Attribute
                                                                 .GetCustomAttributes(action)
                                                                 .Single(x => x is ResponseTypeAttribute);
    
                   var controllerName = apiControllerType.Name.Substring(0,
                       apiControllerType.Name.LastIndexOf("Controller", StringComparison.OrdinalIgnoreCase));
                   var actionName = action.Name;
    
                   GlobalConfiguration.Configuration.SetActualResponseType(responseType.Type, controllerName, actionName);
               }
           }
       }
    }
