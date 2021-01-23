    class User { }
    class UserManager {
        public IEnumerable<User> Users { get { ... } }
    
        public event UserAddedEventHandler UserAdded;
    
    }
    
    
    class UI {
    
        private void AddUserButtonClicked(...) {
            m_userMgr.AddUser(username, ...);
        } 
    
    
    
    }
        
