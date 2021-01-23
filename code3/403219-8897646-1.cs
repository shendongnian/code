        public void SignHttpWebRequest(string token, string tokenSecret, ref HttpWebRequest request)
        {
            NameValueCollection parameters = new NameValueCollection();
            this.tokenSecret = tokenSecret;
            parameters.Set("oauth_token", token);
            request.Headers.Add("Authorization", this.GetAuthorizationHeader(request, parameters));
        }
