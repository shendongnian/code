    class HttpErrorHandler : IErrorHandler
    {
       public bool HandleError(Exception error)
       {
          return false;
       }
    
       public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
       {
          if (fault != null)
          {
             HttpResponseMessageProperty properties = new HttpResponseMessageProperty();
             properties.StatusCode = HttpStatusCode.InternalServerError;
             fault.Properties.Add(HttpResponseMessageProperty.Name, properties);
          }
       }
    }
