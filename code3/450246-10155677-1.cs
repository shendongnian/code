    public class HarooApi
    {
        const string BaseUrl = "https://domain.here";
    
        readonly string _accountSid;
        readonly string _secretKey;
    
        public HarooApi(string accountSid, string secretKey)
        {
            _accountSid = accountSid;
            _secretKey = secretKey;
        }
    
        public void ExecuteAndGetContent(RestRequest request, Action<string> callback)
        {
            var client = new RestClient();
            client.BaseUrl = BaseUrl;
            client.Authenticator = new HttpBasicAuthenticator(_accountSid, _secretKey);
            request.AddParameter("AccountSid", _accountSid, ParameterType.UrlSegment);
            client.ExecuteAsync(request, response =>
            {
                callback(response.Content);
            });
        }
        public void ExecuteAndGetMyClass(RestRequest request, Action<MyClass> callback)
        {
            var client = new RestClient();
            client.BaseUrl = BaseUrl;
            client.Authenticator = new HttpBasicAuthenticator(_accountSid, _secretKey);
            request.AddParameter("AccountSid", _accountSid, ParameterType.UrlSegment);
            client.ExecuteAsync<MyClass>(request, (response) =>
            {
                callback(response.Data);
            });
        }
    }
