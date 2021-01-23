    [WebService(Namespace = "http://example.com/")]
    [System.Web.Script.Services.ScriptService]
    public class api : System.Web.Services.WebService {
        [WebMethod(EnableSession = true)]
        public ServiceResponse<string> SignIn(string _email, string _password) {...}
    }
