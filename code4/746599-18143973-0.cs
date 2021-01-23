    public class ViewModelBase{
    
        public void ViewModelBase()
        {
            GetUserInfo();
        }
        public void GetUserInfo()
        {
            WebUsersEntities db = new WebUsersEntities();
            UserSession = db.UserRegistrationInformations.Where(r => r.uri_UserID == WebSecurity.CurrentUserId).FirstOrDefault();
        }   
        
    }
