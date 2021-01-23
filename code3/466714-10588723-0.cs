    [WebInvoke(UriTemplate = "", Method = "GET")]
    public void RedirectToHelp()
    {          
      WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.Redirect;
      WebOperationContext.Current.OutgoingResponse.Location = "help";
    
    }
