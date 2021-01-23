    public class LoginService
    {
        private User _currentUser;
        public bool Authenticate(string username, string password)
        {
            if (_currentUser != null)
            {
                Logout();
            }
            else
            {
                var user = DataAccess.Get("users").SingleOrDefault(u => u.Username = username);
                if (user == null)
                {
                    throw new Exception("No user with that username found");
                }
                if (password == user.Password)
                {
                    _currentUser = user;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        
        public User CurrentUser
        {
            get { return _user; }
        }
    }
