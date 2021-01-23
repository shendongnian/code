    namespace GoogleAnalyticsAPITest.Console
    {
        using System.Security.Cryptography.X509Certificates;
        using Google.Apis.Analytics.v3;
        using Google.Apis.Analytics.v3.Data;
        using Google.Apis.Authentication.OAuth2;
        using Google.Apis.Authentication.OAuth2.DotNetOpenAuth;
        using Google.Apis.Util;
    
        class Program
        {
            static void Main(string[] args)
            {
                log4net.Config.XmlConfigurator.Configure();            
                const string ServiceAccountId = "nnnnnnnnnnn.apps.googleusercontent.com";
                const string ServiceAccountUser = "nnnnnnnnnnn@developer.gserviceaccount.com";
                AssertionFlowClient client = new AssertionFlowClient(
                    GoogleAuthenticationServer.Description, new X509Certificate2(@"value-privatekey.p12", "notasecret", X509KeyStorageFlags.Exportable))
                {
                    Scope = AnalyticsService.Scopes.AnalyticsReadonly.GetStringValue(),
                    ServiceAccountId = ServiceAccountUser //Bug, why does ServiceAccountUser have to be assigned to ServiceAccountId
                    //,ServiceAccountUser = ServiceAccountUser
                };
                OAuth2Authenticator<AssertionFlowClient> authenticator = new OAuth2Authenticator<AssertionFlowClient>(client, AssertionFlowClient.GetState);            
                AnalyticsService service = new AnalyticsService(authenticator);            
                string profileId = "ga:64968920";
                string startDate = "2010-10-01";
                string endDate = "2010-10-31";
                string metrics = "ga:visits";
                DataResource.GaResource.GetRequest request = service.Data.Ga.Get(profileId, startDate, endDate, metrics);
                request.Dimensions = "ga:date";
                GaData data = request.Fetch();            
            }
    
        }
    }
