    try
    {
        //  Put your code in here
    }
    catch (WebException ex)
    {
        //  Return any exception messages back to the Response header
        OutgoingWebResponseContext response = WebOperationContext.Current.OutgoingResponse;
        response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
        response.StatusDescription = ex.Message.Replace("\r\n", "");
        return null;
    }
    catch (Exception ex)
    {
        //  Return any exception messages back to the Response header
        OutgoingWebResponseContext response = WebOperationContext.Current.OutgoingResponse;
        response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
        response.StatusDescription = ex.Message.Replace("\r\n", "");
        return null;
    }
