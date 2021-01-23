    class Program
        {
            const string ClientId = "abcdef123";
            const string ClientSecret = "Secret";
    
            static void Main(string[] args)
            {
                string Pin = GetPin(ClientId, ClientSecret);
                string Tokens = GetToken(ClientId, ClientSecret, Pin);
    
                // Updoad Images or whatever :)
            }
    
            public static string GetPin(string clientId, string clientSecret)
            {
                string OAuthUrlTemplate = "https://api.imgur.com/oauth2/authorize?client_id={0}&response_type={1}&state={2}";
                string RequestUrl = String.Format(OAuthUrlTemplate, clientId, "pin", "whatever");
                string Pin = String.Empty;
    
                // Promt the user to browse to that URL or show the Webpage in your application
                // ... 
    
                return Pin;
            }
    
            public static ImgurToken GetToken(string clientId, string clientSecret, string pin)
            {
                string Url = "https://api.imgur.com/oauth2/token/";
                string DataTemplate = "client_id={0}&client_secret={1}&grant_type=pin&pin={2}";
                string Data = String.Format(DataTemplate, clientId, clientSecret, pin);
    
                using(WebClient Client = new WebClient())
                {
                    string ApiResponse = Client.UploadString(Url, Data);
    
                    // Use some random JSON Parser, you´ll get access_token and refresh_token
                    var Deserializer = new JavaScriptSerializer();
                    var Response = Deserializer.DeserializeObject(ApiResponse) as Dictionary<string, object>;
    
                    return new ImgurToken()
                    {
                        AccessToken = Convert.ToString(Response["access_token"]),
                        RefreshToken = Convert.ToString(Response["refresh_token"])
                    };
                }
            }
        }
    
        public class ImgurToken
        {
            public string AccessToken { get; set; }
            public string RefreshToken { get; set; }
        }
