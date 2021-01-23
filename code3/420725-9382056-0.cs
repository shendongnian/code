    using System;
    using DotNetOpenAuth.OAuth2;
    using Google.Apis.Authentication.OAuth2;
    using AnalyticsService = Google.Apis.Analytics.v3.AnalyticsService;
    
    class Program
        {
            public static void Main()
            {
                var client = new WebServerClient(GoogleAuthenticationServer.Description, "YOUR_APP_ID.apps.googleusercontent.com", "YOUR_APPS_SECRET_CODE");
                var auth = new OAuth2Authenticator<WebServerClient>(client, Authenticate);
                var asv = new AnalyticsService(auth);
                var request = asv.Report.Get("2012-02-20", "2012-01-01", "ga:visitors", "ga:YOUR_GOOGLE_ANALYTICS_ACCOUNT_ID");
                request.Dimensions = "ga:pagePath";
                request.Sort = "-ga:visitors";
                request.MaxResults = 5;
                var report =  request.Fetch();
                Console.ReadLine();
            }
    
            private static IAuthorizationState Authenticate(WebServerClient client)
            {
                IAuthorizationState state = new AuthorizationState(new string[]{}) { RefreshToken = "REFRESH_TOKEN" };
    
                client.RefreshToken(state);
                return state;
            }
        }
