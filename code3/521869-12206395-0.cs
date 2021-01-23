    public static void HandleRestServiceError(Exception exception, Action<TServiceResult> serviceResultHandler, Action<TServiceFault> serviceFaultHandler = null, Action<Exception> exceptionHandler = null)
    {
      var serviceResultOrServiceFaultHandled = false;
      
      if (exception == null) throw new ArgumentNullException("exception");
      if (serviceResultHandler == null) throw new ArgumentNullException("serviceResultHandler");
      
      // REST uses the HTTP procol status codes to communicate errors that happens on the service side.
      // This means if we have a teller service and you need to supply username and password to login
      // and you do not supply the password, a possible scenario is that you get a 400 - Bad request.
      // However it is still possible that the expected type is returned so it would have been possible 
      // to process the response - instead it will manifest as a ProtocolException on the client side.
      var protocolException = exception as ProtocolException;
      if (protocolException != null)
      {
        var webException = protocolException.InnerException as WebException;
        if (webException != null)
        {
          var responseStream = webException.Response.GetResponseStream();
          if (responseStream != null)
          {
            try
            {
              // Debugging code to be able to see the reponse in clear text
              //SeeResponseAsClearText(responseStream);
      
              // Try to deserialize the returned XML to the expected result type (TServiceResult)
              var response = (TServiceResult) GetSerializer(typeof(TServiceResult)).ReadObject(responseStream);
              serviceResultHandler(response);
              serviceResultOrServiceFaultHandled = true;
            }
            catch (SerializationException serializationException)
            {
              // This happens if we try to deserialize the responseStream to type TServiceResult
              // when an error occured on the service side. An service side error serialized object 
              // is not deserializable into a TServiceResult
      
              // Reset responseStream to beginning and deserialize to a TServiceError instead
              responseStream.Seek(0, SeekOrigin.Begin);
      
              var serviceFault = (TServiceFault) GetSerializer(typeof(TServiceFault)).ReadObject(responseStream);
      
              if (serviceFaultHandler != null && serviceFault != null)
              {
                serviceFaultHandler(serviceFault);
                serviceResultOrServiceFaultHandled = true;
              }
              else if (serviceFaultHandler == null && serviceFault != null)
              {
                throw new WcfServiceException<TServiceFault>() { ServiceFault = serviceFault };
              }
            }
          }
        }
      }
      
      // If we have not handled the serviceResult or the serviceFault then we have to pass it on to the exceptionHandler delegate
      if (!serviceResultOrServiceFaultHandled && exceptionHandler != null)
      {
        exceptionHandler(exception);
      }
      else if (!serviceResultOrServiceFaultHandled && exceptionHandler == null)
      {
        // Unable to handle and no exceptionHandler passed in throw exception to be handled at a higher level
        throw exception;
      }
    }
