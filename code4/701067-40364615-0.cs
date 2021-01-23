    public class PayPalClient
    {
        public async Task RequestPayPalToken() 
        {
            // Discussion about SSL secure channel
            // http://stackoverflow.com/questions/32994464/could-not-create-ssl-tls-secure-channel-despite-setting-servercertificatevalida
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            try
            {
                // ClientId of your Paypal app API
                string APIClientId = "**_[your_API_Client_Id]_**";
                // secret key of you Paypal app API
                string APISecret = "**_[your_API_secret]_**";
                using (var client = new System.Net.Http.HttpClient())
                {
                    var byteArray = Encoding.UTF8.GetBytes(APIClientId + ":" + APISecret);
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                    var url = new Uri("https://api.sandbox.paypal.com/v1/oauth2/token", UriKind.Absolute);
                    client.DefaultRequestHeaders.IfModifiedSince = DateTime.UtcNow;
                    var requestParams = new List<KeyValuePair<string, string>>
                                {
                                    new KeyValuePair<string, string>("grant_type", "client_credentials")
                                };
                    var content = new FormUrlEncodedContent(requestParams);
                    var webresponse = await client.PostAsync(url, content);
                    var jsonString = await webresponse.Content.ReadAsStringAsync();
                    // response will deserialized using Jsonconver
                    var payPalTokenModel = JsonConvert.DeserializeObject<PayPalTokenModel>(jsonString);
                }
            }
            catch (System.Exception ex)
            {
                //TODO: Log connection error
            }
        }
    }
    public class PayPalTokenModel 
    {
        public string scope { get; set; }
        public string nonce { get; set; }
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string app_id { get; set; }
        public int expires_in { get; set; }
    }
