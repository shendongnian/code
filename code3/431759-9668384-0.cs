      public class MvcApplication : HttpApplication
      {
        public MvcApplication()
        {
          this.AuthorizeRequest += this.AuthorizedRequestEvent;
        }
    
        private void AuthorizedRequestEvent(object sender, System.EventArgs e)
        {
          // do checking here with what ever you want
          bool isAuthenicated = false;
    
          // change this what what ever implements IIdentity
          var user = new User(); 
          user.IsAuthenticated = isAuthenicated ;
          GenericPrincipal principal;
          principal = new GenericPrincipal(user, new string[] { });
          HttpContext.Current.User = principal;
        }
       }
