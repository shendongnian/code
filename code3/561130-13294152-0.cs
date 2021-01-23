    public class MyAuthorizationModule : IHttpModule
    {
        
        public void Init(HttpApplication application)
        {
            application.AuthorizeRequest += (new EventHandler(AuthorizeRequest));
        }
        private void AuthorizeRequest(Object source, EventArgs e)
        {
            bool isAuthorized = //your code here to check page authorization
            if (!isAuthorized) 
            {  
                var response = //will need to get current response
                response.Redirect("Login.aspx", true);
            }
        }
    }
