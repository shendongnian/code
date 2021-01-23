    using System.Security.Cryptography.X509Certificates;
    using DotNetOpenAuth.OAuth2;
    using Google.Apis.Analytics.v3;
    using Google.Apis.Analytics.v3.Data;
    using Google.Apis.Authentication.OAuth2;
    using Google.Apis.Authentication.OAuth2.DotNetOpenAuth;
    using Google.Apis.Services;
    
           
            private void TestMethod()
            {
                try
                {
                    string scope_url = "https://www.googleapis.com/auth/analytics.readonly";
    
                    //client_id: This is the "Email Address" one, not the "Client ID" one... oddly...
                    string client_id = "************-***********************@developer.gserviceaccount.com";
    
                    //key_file: This is the physical path to the key file you downloaded when you created your Service Account
                    string key_file = @"***************************************-privatekey.p12";
    
                    //key_pass: This is probably the password for all key files, but if you're given a different one, use that.
                    string key_pass = "notasecret";
    
    
                    AuthorizationServerDescription desc = GoogleAuthenticationServer.Description;
    
                    //key: Load up and decrypt the key
                    X509Certificate2 key = new X509Certificate2(key_file, key_pass, X509KeyStorageFlags.Exportable);
    
                    //client: we're using the AssertionFlowClient, because we're logging in with our certificate
                    AssertionFlowClient client = new AssertionFlowClient(desc, key) { ServiceAccountId = client_id, Scope = scope_url };
                    OAuth2Authenticator<AssertionFlowClient> auth = new OAuth2Authenticator<AssertionFlowClient>(client, AssertionFlowClient.GetState);
    
                    //gas: An instance of the AnalyticsService we can query
                    // AnalyticsService gas = null;// new AnalyticsService(auth);
    
                    var gas = new AnalyticsService(new BaseClientService.Initializer()
                    {
                        Authenticator = auth
                    });
                    //r: Creating our query
                    DataResource.GaResource.GetRequest r = gas.Data.Ga.Get("ga:*******", "2012-09-26", "2012-10-10", "ga:visitors");
    
                    //d: Execute and fetch the results of our query
                    GaData d = r.Fetch();
                }
                catch (Exception ex)
                {
                    
                    throw;
                }
            }
        
