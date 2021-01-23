		  public class CustomCredentialsAuthProvider : CredentialsAuthProvider
		    {
		        public override bool TryAuthenticate(IServiceBase authService, string userName, string password)
		        {
		            //NOTE: We always authenticate because we are always a Windows user! 
		            // Yeah, it's an intranet  
		            return true;
		        }
		        public override void OnAuthenticated(IServiceBase authService, IAuthSession session, IOAuthTokens tokens, Dictionary<string, string> authInfo)
		        {
		            
		            // Here is why we set windows authentication in web.config
		            var userName = HttpContext.Current.User.Identity.Name;
		            //  Strip off the domain
		            userName = userName.Split('\\')[1].ToLower();
		            // Now we call our custom method to figure out what to do with this user
		            var userAuth = SetUserAuth(userName);
		            // Patch up our session with what we decided
		            session.UserName = userName;
		            session.Roles = userAuth.Roles;            
		            // And save the session so that it will be cached by ServiceStack 
		            authService.SaveSession(session, SessionExpiry);
		        }
		    }
