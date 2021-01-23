    public class BaseClass
    {
        public virtual void Updated() { }
        public void Update()
        {
            RestClient client = new RestClient("https://www.googleapis.com");
            client.Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(App.AuthenticationResult.access_token);
            var request = new RestRequest(path, Method.GET);
            //implement whatever logic you want with the response.
            this.Updated(); //include whatever parameters you need to pass.
        }
    }
    public class Class1 : BaseClass
    {
        public override void Updated()
        {
            //implement logic specific to Class1...
        }
    }
