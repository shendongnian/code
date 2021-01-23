        public sealed class SW
        {
            private static User _currentUser;
            public static User GetCurrentUser()
            {
                if (_currentUser == null)
                {
                    tblUsers users = new tblUsers();
                    users.LoadByID(userId);
                    HttpContext.Current.Session["dtUser"] = users;
                    _currentUser = users[0];
                }
                return _currentUser;
            }
            public static void User_Load(string userId)
            {
                UserProvider.CurrentUserDelegate = new Func<User>(GetCurrentUser);
            }
        }
