    using System; 
    using System.Diagnostics; 
    using System.Collections.Generic; 
    using DotNetOpenAuth.OAuth2; 
    using Google.Apis.Authentication.OAuth2; 
    using Google.Apis.Authentication.OAuth2.DotNetOpenAuth; 
    using Google.Apis.Coordinate.v1; 
    using Google.Apis.Coordinate.v1.Data;
    
    namespace Google.Apis.Samples.CoordinateOAuth2
    { 
        /// <summary> 
        /// This sample demonstrates the simplest use case for an OAuth2 service. 
        /// The schema provided here can be applied to every request requiring authentication. 
        /// </summary> 
    	public class ProgramWebServer
    	{ 
    		public static void Main (string[] args)
    		{ 
    			// TO UPDATE, can be found in the Coordinate application URL
    			String TEAM_ID = "jskdQ--xKjFiFqLO-IpIlg"; 
    
    			// Register the authenticator. 
    			var provider = new WebServerClient (GoogleAuthenticationServer.Description);
    			// TO UPDATE, can be found in the APIs Console.
    			provider.ClientIdentifier = "335858260352.apps.googleusercontent.com";
    			// TO UPDATE, can be found in the APIs Console.
    			provider.ClientSecret = "yAMx-sR[truncated]fX9ghtPRI"; 
    			var auth = new OAuth2Authenticator<WebServerClient> (provider, GetAuthorization); 
    
    			// Create the service. 
    			var service = new CoordinateService(new BaseClientService.Initializer()
                           {
                              Authenticator = auth
                           });
    
    			//Create a Job Resource for optional parameters https://developers.google.com/coordinate/v1/jobs#resource 
    			Job jobBody = new Job (); 
    			jobBody.Kind = "Coordinate#job"; 
    			jobBody.State = new JobState (); 
    			jobBody.State.Kind = "coordinate#jobState"; 
    			jobBody.State.Assignee = "user@example.com"; 
    
    
    			//Create the Job 
    			JobsResource.InsertRequest ins = service.Jobs.Insert (jobBody, TEAM_ID, "My Home", "51", "0", "Created this Job with the .Net Client Library");
    			Job results = ins.Fetch (); 
    
    			//Display the response 
    			Console.WriteLine ("Job ID:"); 
    			Console.WriteLine (results.Id.ToString ()); 
    			Console.WriteLine ("Press any Key to Continue"); 
    			Console.ReadKey (); 
    		}
    
    		private static IAuthorizationState GetAuthorization (WebServerClient client)
    		{ 
    			IAuthorizationState state = new AuthorizationState (new[] { "https://www.googleapis.com/auth/coordinate" }); 
    			// The refresh token has already been retrieved offline
    			// In a real-world application, this has to be stored securely, since this token
    			// gives access to all user data on the Coordinate scope, for the user who accepted the OAuth2 flow
    			// TO UPDATE (see below the sample for instructions)
    			state.RefreshToken = "1/0KuRg-fh9yO[truncated]yNVQcXcVYlfXg";
    
    			return state;
    		} 
    
    	} 
    }
