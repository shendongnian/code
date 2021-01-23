    String[] _users = null;
    String[] users
    {
        get
        {
            if (_users == null)
            {
                Application.Lock();
                if (!(Application["_users_"] is String[]))
                {
                    Application["_users_"] = new String[1000];
                }
                _users = (String [])Application["_users_"];
                Application.UnLock();
            }
    
            return _users;
        }
    }
