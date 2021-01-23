    using System;
    using System.Diagnostics;
    using DotNetOpenAuth.OAuth2;
    using Google.Apis.Authentication.OAuth2;
    using Google.Apis.Authentication.OAuth2.DotNetOpenAuth;
    using Google.Apis.Drive.v2;
    using Google.Apis.Drive.v2.Data;
    using Google.Apis.Util;
    
    namespace GoogleDriveSamples
    {
        class DriveCommandLineSample
        {
            static void Main(string[] args)
            {
                String CLIENT_ID = "YOUR_CLIENT_ID";
                String CLIENT_SECRET = "YOUR_CLIENT_SECRET";
    
                // Register the authenticator and create the service
                var provider = new NativeApplicationClient(GoogleAuthenticationServer.Description, CLIENT_ID, CLIENT_SECRET);
                var auth = new OAuth2Authenticator<NativeApplicationClient>(provider, GetAuthorization);
                {
                    Authenticator = auth
                });
    
                File body = new File();
                body.Title = "My document";
                body.Description = "A test document";
                body.MimeType = "text/plain";
    
                byte[] byteArray = System.IO.File.ReadAllBytes("document.txt");
                System.IO.MemoryStream stream = new System.IO.MemoryStream(byteArray);
    
                FilesResource.InsertMediaUpload request = service.Files.Insert(body, stream, "text/plain");
                request.Upload();
    
                File file = request.ResponseBody;
                Console.WriteLine("File id: " + file.Id);
                Console.ReadLine();
            }
    
            private static IAuthorizationState GetAuthorization(NativeApplicationClient arg)
            {
                // Get the auth URL:
                IAuthorizationState state = new AuthorizationState(new[] { DriveService.Scopes.Drive.GetStringValue() });
                state.Callback = new Uri(NativeApplicationClient.OutOfBandCallbackUrl);
                Uri authUri = arg.RequestUserAuthorization(state);
    
                // Request authorization from the user (by opening a browser window):
                Process.Start(authUri.ToString());
                Console.Write("  Authorization Code: ");
                string authCode = Console.ReadLine();
                Console.WriteLine();
    
                // Retrieve the access token by using the authorization code:
                return arg.ProcessUserAuthorization(authCode, state);
            }
        }
    }
