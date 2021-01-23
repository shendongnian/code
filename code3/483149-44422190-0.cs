        public void AccessAPI ()
        {
            InMemoryOAuthTokenManager tokenManager = InMemoryOAuthTokenManager(YOUR_CLIENT_KEY, YOUR_CLIENT_SECRET);
            var consumer = new DesktopConsumer(GetAuthServerDescription(), tokenManager);
            
                // Get Request token
                string requestToken;
                var parameters = new Dictionary<string, string>();
                parameters["email"] = "foo";
                parameters["password"] = "bar";
                Uri authorizationUrl = consumer.RequestUserAuthorization(null, parameters, out requestToken);
                // Authorize and get a verifier (No OAuth Header necessary for the API I wanted to access)
                var request = WebRequest.Create(authorizationUrl) as HttpWebRequest;
                request.Method = "Get";
                request.Accept = "text/html, image/gif, image/jpeg, *; q=.2, */*; q=.2";
                var response = request.GetResponse() as HttpWebResponse;
                string verifier = new StreamReader(response.GetResponseStream()).ReadToEnd().Split('=')[1]; //Irgendwie will Json nicht parsen
                // Use verifier to get the final AccessToken
                AuthorizedTokenResponse authorizationResponse = consumer.ProcessUserAuthorization(requestToken, verifier);
                string accessToken = authorizationResponse.AccessToken;
                // Access Ressources
                HttpDeliveryMethods resourceHttpMethod = HttpDeliveryMethods.GetRequest | HttpDeliveryMethods.AuthorizationHeaderRequest;
                var resourceEndpoint = new MessageReceivingEndpoint("https://api.discovergy.com/public/v1/meters", resourceHttpMethod);
                using (IncomingWebResponse resourceResponse = consumer.PrepareAuthorizedRequestAndSend(resourceEndpoint, accessToken))
                {
                    string result = resourceResponse.GetResponseReader().ReadToEnd();
                    dynamic content = JObject.Parse(result);
                }
        }
        private ServiceProviderDescription GetAuthServerDescription()
        {
            var authServerDescription = new ServiceProviderDescription();
            authServerDescription.RequestTokenEndpoint = new MessageReceivingEndpoint(YOUR_REQUEST_ENDPOINT, HttpDeliveryMethods.PostRequest | HttpDeliveryMethods.AuthorizationHeaderRequest);
            authServerDescription.UserAuthorizationEndpoint = new MessageReceivingEndpoint(YOUR_AUTHORIZATION_ENDPOINT, HttpDeliveryMethods.GetRequest | HttpDeliveryMethods.AuthorizationHeaderRequest);
            authServerDescription.AccessTokenEndpoint = new MessageReceivingEndpoint(YOUR_TOKEN_ENDPOINT, HttpDeliveryMethods.PostRequest | HttpDeliveryMethods.AuthorizationHeaderRequest);
            authServerDescription.ProtocolVersion = ProtocolVersion.V10;
            authServerDescription.TamperProtectionElements = new ITamperProtectionChannelBindingElement[] { new HmacSha1SigningBindingElement() };
            return authServerDescription;
        }
