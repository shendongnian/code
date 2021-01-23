    public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
    {
        var faultEx = error as FaultException;
        bool isRest = version == MessageVersion.None;
        if (isRest && faultEx == null)
        {
            OutgoingWebResponseContext response = WebOperationContext.Current.OutgoingResponse;
            if (response.StatusCode == HttpStatusCode.BadRequest) {
                response.StatusCode = HttpStatusCode.InternalServerError;
            }
        }
    }
