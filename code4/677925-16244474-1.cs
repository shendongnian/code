    public class UserData
    {
        public string FirstName { get; set; }
        public UserData()
        {
            FirstName = "Unknown";
        }
    } // End Class UserData
    public void SignIn(string userName, bool createPersistentCookie)
    {
        if (String.IsNullOrEmpty(userName)) 
            throw new ArgumentException("Der Wert darf nicht NULL oder leer sein.", "userName");
        UserData userData = new UserData();
        SetAuthCookie(userName, createPersistentCookie, userData);
        //FormsAuthentication.SetAuthCookie(userName, createPersistentCookie);
    }
    public void SetAuthCookie(string userName, bool createPersistentCookie, UserData userData)
    {
        HttpCookie cookie = FormsAuthentication.GetAuthCookie(userName, createPersistentCookie);
        FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);
        FormsAuthenticationTicket newTicket = new FormsAuthenticationTicket(
             ticket.Version, ticket.Name, ticket.IssueDate, ticket.Expiration
            ,ticket.IsPersistent, userData.ToJSON(), ticket.CookiePath
        );
        string encTicket = FormsAuthentication.Encrypt(newTicket);
        cookie.Value = encTicket;
        System.Web.HttpContext.Current.Response.Cookies.Add(cookie);
    } // End Sub SetAuthCookie
