    public override void OnException(HttpActionExecutedContext actionExecutedContext) {
       if (actionExecutedContext == null || actionExecutedContext.Exception == null) {
          return;
       }
        
       var type = actionExecutedContext.Exception.GetType();
        
       Tuple<HttpStatusCode?, Func<Exception, HttpRequestMessage, HttpResponseMessage>> registration = null;
        
       if (!this.Handlers.TryGetValue(type, out registration)) {
          //tento di vedere se ho registrato qualche eccezione che eredita dal tipo di eccezione sollevata (in ordine di registrazione)
          foreach (var item in this.Handlers.Keys) {
             if (type.IsSubclassOf(item)) {
                registration = this.Handlers[item];
                break;
             }
          }
       }
        
       //se ho trovato un tipo compatibile, uso la sua gestione
       if (registration != null) {
          var statusCode = registration.Item1;
          var handler = registration.Item2;
        
          var response = handler(
             actionExecutedContext.Exception.GetBaseException(),
             actionExecutedContext.Request
          );
        
          // Use registered status code if available
          if (statusCode.HasValue) {
             response.StatusCode = statusCode.Value;
          }
        
          actionExecutedContext.Response = response;
       }
       else {
          // If no exception handler registered for the exception type, fallback to default handler
          actionExecutedContext.Response = DefaultHandler(actionExecutedContext.Exception.GetBaseException(), actionExecutedContext.Request
          );
       }
    }
