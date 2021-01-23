        [Test]
        public void MakeCallToBossGeoApi()
        {
            string result;
            var uri = new Uri(@"http://yboss.yahooapis.com/geo/placefinder?country=SE&flags=J&locale=sv_SE&postal=41311");
            var o = new OAuthBase();
            string nonce = o.GenerateNonce();
            var timestamp = o.GenerateTimeStamp();
            string normalizedUrl;
            string normalizedParameters;
            string signature = HttpUtility.UrlEncode(
                o.GenerateSignature(uri,
                                    "yourconsumerkeyhere",
                                    "yourconsumersecrethere", null, null, "GET",
                                    timestamp, nonce, out normalizedUrl,
                                    out normalizedParameters));
            uri = new Uri(normalizedUrl +"?"+ normalizedParameters + "&oauth_signature=" + signature );
            using (var httpClient = new WebClient())
            {
                result = httpClient.DownloadString(uri.AbsoluteUri);
            }
            
            Console.WriteLine(result);
        }
