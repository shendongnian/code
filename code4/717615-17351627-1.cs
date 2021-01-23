    [System.Web.Http.HttpPost]
    public LoginResponseModel Post(LoginModel loginRequest)
    {
        ...
        
        return new LoginResponseModel() { LoginSuccessful = true, ErrorMessage = "" };
    }
