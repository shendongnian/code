        /// <summary>
        /// Gets the authorization header.
        /// </summary>
        /// <param name="method">The method.</param>
        /// <param name="url">The URL of the request.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Authorization header</returns>
        public string GetAuthorizationHeader(string method, Uri url, NameValueCollection parameters)
        {
            parameters.Set("oauth_consumer_key", this.ConsumerKey);
            parameters.Set("oauth_nonce", this.GetNonce());
            parameters.Set("oauth_timestamp", this.GetTimeStamp());
            parameters.Set("oauth_version", "1.0");
            parameters.Set("oauth_signature_method", "HMAC-SHA1");
            string signString = this.GetSignString(method, url, parameters);
            string signature = this.GetSignature(signString, this.ConsumerSecret, this.tokenSecret);
            parameters.Set("oauth_signature", signature);
            StringBuilder authorizationHeader = new StringBuilder();
            foreach (string paramKey in parameters.AllKeys)
            {
                if (authorizationHeader.Length > 0)
                {
                    authorizationHeader.Append(", ");
                }
                else
                {
                    authorizationHeader.Append("OAuth ");
                }
                authorizationHeader.AppendFormat("{0}=\"{1}\"", paramKey, OAuthHelper.UrlEncode(parameters[paramKey]));
            }
            return authorizationHeader.ToString();
        }
