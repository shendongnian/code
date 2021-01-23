    class User { }
    class UserManager {
        public IEnumerable<User> Users { get { ... } }
    
        public event UserLoggedInEventHandler UserLoggedIn;
    
    }
    
    
    class UI {
        private UserManager m_usrMgr;
        public UI() {
            m_usrMgr = UserManager.GetSingletonInstance();
            m_usrMgr.UserLoggedIn += UserLoggedInHandler;
        }
    
        private void AddUserButtonClicked(...) {
            m_userMgr.AddUser(username, ...);
        } 
    
        private void UserLoggedInHandler(...) {
            MessageBox.Show("User x logged in");
        }
    }
        
