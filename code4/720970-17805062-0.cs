    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Security.Cryptography;
    using System.Security.Cryptography.X509Certificates;
    using DotNetOpenAuth.OAuth2;
    using Google.Apis.Authentication.OAuth2;
    using Google.Apis.Authentication.OAuth2.DotNetOpenAuth;
    using Google.Apis.Samples.Helper;
    using Google.Apis.Services;
    using Google.Apis.Util;
    using Google.Apis.Admin.directory_v1;
    using Google.Apis.Admin.directory_v1.Data;
    namespace Bergstedts.CreateNewUser
    {
        public class Program
        {
        static void Main(string[] args)
        {
             // Display the header and initialize the sample.
            CommandLine.EnableExceptionHandling();
            Console.WriteLine("Create users in a google apps domain!");
            Console.WriteLine("by Jonas Bergstedt 2013");
                        
            // Get the user data and store in user object
            Console.Write("Email: ");
            string userId = Console.ReadLine();
            
            Console.Write("Givenname: ");
            string GivenName = Console.ReadLine();
                                    
            Console.Write("Familyname: ");
            string FamilyName = Console.ReadLine();
                       
            Console.Write("Password: ");
            string Password = Console.ReadLine();
            User newuserbody = new User();
            UserName newusername = new UserName();
            newuserbody.PrimaryEmail = userId;
            newusername.GivenName = GivenName;
            newusername.FamilyName = FamilyName;
            newuserbody.Name = newusername;
            newuserbody.Password = Password;
            // Register the authenticator.
            var provider = new NativeApplicationClient(GoogleAuthenticationServer.Description)
                {
                    ClientIdentifier = "<your clientId from Google APIs Console>",
                    ClientSecret = "<your clientsecret from Google APIs Console>",
                };
            var auth = new OAuth2Authenticator<NativeApplicationClient>(provider, GetAuthorization);
            // Create the service.
            var service = new DirectoryService(new BaseClientService.Initializer()
                {
                    Authenticator = auth,
                    ApplicationName = "Create User",
                    ApiKey = "<your API Key from Google APIs console> (not sure if needed)"             
                });
            User results = service.Users.Insert(newuserbody).Execute();
            Console.WriteLine("User :" + results.PrimaryEmail + " is created");
            Console.WriteLine("Press any key to continue!");
            Console.ReadKey();
        }
        private static IAuthorizationState GetAuthorization(NativeApplicationClient arg)
        {
            // Get the auth URL:
            IAuthorizationState state = new AuthorizationState(new[] { DirectoryService.Scopes.AdminDirectoryUser.GetStringValue() });
            state.Callback = new Uri(NativeApplicationClient.OutOfBandCallbackUrl);
            Uri authUri = arg.RequestUserAuthorization(state);
            // Request authorization from the user (by opening a browser window):
            Process.Start(authUri.ToString());
            Console.WriteLine();
            Console.Write("Authorization Code: ");
            string authCode = Console.ReadLine();
            // Retrieve the access token by using the authorization code:
           return arg.ProcessUserAuthorization(authCode, state);
        }
    }
}
