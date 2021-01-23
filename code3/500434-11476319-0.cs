    public class LoginModel
    {
       public string username { get; set; }
       public string password { get; set; }
    }
    public class Result
    {
       public bool success { get; set; }
       public string error { get; set; }
    }
    [WebInvoke(Method = "POST",
    RequestFormat = WebMessageFormat.Json,
    ResponseFormat = WebMessageFormat.Json,
    UriTemplate = "/LogIn")]
    public Result login(LoginModel loginModel)
