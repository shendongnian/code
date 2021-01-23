            if (ServicePointManager.SecurityProtocol != SecurityProtocolType.Tls12) ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12; // forced to modern day SSL protocols
            var client = new RestClient(payPalUrl) { Encoding = Encoding.UTF8 };
            var authRequest = new RestRequest("oauth2/token", Method.POST) {RequestFormat = DataFormat.Json};
            client.Authenticator = new HttpBasicAuthenticator(clientId, secret);
            authRequest.AddParameter("grant_type","client_credentials");
            var authResponse = client.Execute(authRequest);
            // You can now deserialise the response to get the token as per the answer from @ryuzaki 
            var payPalTokenModel = JsonConvert.DeserializeObject<PayPalTokenModel>(authResponse.Content);
