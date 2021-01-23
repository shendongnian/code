    private void ResponseHandler(Response result, Exception error)
    {
        if (error != null)
        {
            string err = error.Message;
            return;
        }
        var signInResponse = result as ResponseSignin;
        if (signInResponse != null)
        {
            HandleSignInResponse(signInResponse);
        }
        var infoResponse = result as ResponseGetInfo;
        if (infoResponse != null)
        {
            HandleInfoResponse(infoResponse);
        }
    }
