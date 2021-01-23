        public string[] Roles { get; private set; }
        public string FirstName { get; private set; }
        public string UserName { get; private set; }
        public int UserID { get; private set; }
        public UserIdentity(System.Web.Security.FormsAuthenticationTicket ticket) : base(ticket)
        {
            if (ticket.UserData != null && ticket.UserData.IndexOf("|") != -1)
            {
                string[] dataSections = ticket.UserData.Split('|');
                //Get the first name
                FirstName = dataSections.Length >= 3 ? dataSections[2] : "";
                //Get the username
                UserName = ticket.Name;
                #region Parse the UserID
                int userID = 0;
                int.TryParse(dataSections[0], out userID);
                this.UserID = userID;
                #endregion
                this.Roles = System.Text.RegularExpressions.Regex.Split(dataSections[1], ",");
            }
        }
    }
    public class UserPrincipal : System.Security.Principal.GenericPrincipal
    {
        public UserPrincipal(UserIdentity identity) : base(identity, identity.Roles )
        {
        }
    }
        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            if (HttpContext.Current.User != null && HttpContext.Current.User.Identity.IsAuthenticated && HttpContext.Current.User.Identity is System.Web.Security.FormsIdentity)
            {
                HttpContext.Current.User = new CAA.Utility.Security.UserPrincipal(HttpContext.Current.User.Identity is CAA.Utility.Security.UserIdentity?  HttpContext.Current.User.Identity as CAA.Utility.Security.UserIdentity : new Utility.Security.UserIdentity(((System.Web.Security.FormsIdentity)HttpContext.Current.User.Identity).Ticket));                
            }
        }
