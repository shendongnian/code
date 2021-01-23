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
    
        public string ExecuteAndGetContent(RestRequest request) where T : new()
        {
            var client = new RestClient();
            client.BaseUrl = BaseUrl;
            client.Authenticator = new HttpBasicAuthenticator(_accountSid, _secretKey);
            request.AddParameter("AccountSid", _accountSid, ParameterType.UrlSegment);
            client.ExecuteAsync(request, (response) =>
            {
                return response.Content;
            });
        }
    
        public MyClass ExecuteAndGetMyClass(RestRequest request) where T : new()
        {
            var client = new RestClient();
            client.BaseUrl = BaseUrl;
            client.Authenticator = new HttpBasicAuthenticator(_accountSid, _secretKey);
            request.AddParameter("AccountSid", _accountSid, ParameterType.UrlSegment);
            client.ExecuteAsync<MyClass>(request, (response) =>
            {
                return response.Data;
            });
        }
    }
