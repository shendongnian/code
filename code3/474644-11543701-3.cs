    public static void ExecuteServiceMethod(this IMyRESTService svc, Action svcMethod)
    {
        // try to get first last error here
        string lastError = svc.CommHandler.CH_TryGetLastError();
        if (!String.IsNullOrEmpty(lastError))
           throw new WebFaultException<string>(lastError, System.Net.HttpStatusCode.InternalServerError);
    
        try
        {
           // execute service method
           svcMethod();
        }
        catch (CommHandlerException ex)
        {
           // we use for now only 'InternalServerError'
           if (ex.InnerException != null)
               throw new WebFaultException<string>(ex.InnerException.Message, System.Net.HttpStatusCode.InternalServerError);
           else
               throw new WebFaultException<string>(ex.Message, System.Net.HttpStatusCode.InternalServerError);
         }
         catch (Exception ex)
         {
            throw new WebFaultException<string>(ex.Message, System.Net.HttpStatusCode.InternalServerError);
         }
    }
