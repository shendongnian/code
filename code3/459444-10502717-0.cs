        /// <summary>
        /// Renews the token.. (offline deprecation)
        /// </summary>
        /// <param name="existingToken">The token to renew</param>
        /// <returns>A new token (or the same as existing)</returns>
        public static string RenewToken(string existingToken)
        {
            var fb = new FacebookClient();
            dynamic result = fb.Get("oauth/access_token", 
                                    new {
                                        client_id         = FACEBOOK_APP_ID,
                                        client_secret     = FACEBOOK_APP_SECRET,
                                        grant_type        = "fb_exchange_token",
                                        fb_exchange_token = existingToken
                                    });
            return result.access_token;            
        }
