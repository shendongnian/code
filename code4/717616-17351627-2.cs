    [System.Web.Http.HttpPost]
    public HttpResponseMessage Post(LoginModel loginRequest)
    {
        ...
        
        var resp = Request.CreateResponse<LoginResponseModel>(
            HttpStatusCode.OK,
            new LoginResponseModel() { LoginSuccessful = true, ErrorMessage = "" }
        );
        return resp;
    }
