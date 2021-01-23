    private const string Scope = "https://www.googleapis.com/auth/analytics.readonly";
        static void Main(string[] args)
        {
            try
            {
                var provider = new NativeApplicationClient(GoogleAuthenticationServer.Description);
                provider.ClientIdentifier = "Your_Client_ID";
                provider.ClientSecret = "Your_Client_Secret";
                var auth = new OAuth2Authenticator<NativeApplicationClient>(provider, GetAuthentication);
                var asv = new AnalyticsService(auth);
                var request = asv.Data.Ga.Get("ga:Your_TrackingID", "2013-08-05", "2013-08-05", "ga:visitors");
                request.Dimensions = "ga:visitorType";
                var report = request.Fetch();
                var rows = report.Rows;
                var newVisitors = rows[0];
                var returnVisitors = rows[1];
                Console.WriteLine(newVisitors[0] + ": " + newVisitors[1]);
                Console.WriteLine(returnVisitors[0] + ": " + returnVisitors[1]);
                int newV = Int32.Parse(newVisitors[1]);
                int retV = Int32.Parse(returnVisitors[1]);
                int sum = newV + retV;
                Console.WriteLine("Total:  " + sum);
            }
            catch(Exception ex){
                Console.WriteLine("\n Error: \n" + ex);
                Console.ReadLine();
            }
        }
    private static IAuthorizationState GetAuthentication(NativeApplicationClient arg)
        {
            IAuthorizationState state = new AuthorizationState(new[] { Scope });
            state.Callback = new Uri(NativeApplicationClient.OutOfBandCallbackUrl);
            Uri authUri = arg.RequestUserAuthorization(state);
            System.Diagnostics.Process.Start(authUri.ToString());
            Console.Write("Paste authorization code: ");
            string authCode = Console.ReadLine();
            return arg.ProcessUserAuthorization(authCode, state);
        }
