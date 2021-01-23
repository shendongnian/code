    public static class SessionManager
        {
            private static List<User> _sessions = new List<User>();
    
            public static void RegisterLogin(User user)
            {
                if (user != null)
                {
                    _sessions.RemoveAll(u => u.UserName == user.UserName);
                    _sessions.Add(user);
                }
            }
    
            public static void DeregisterLogin(User user)
            {
                if (user != null)
                    _sessions.RemoveAll(u => u.UserName == user.UserName && u.SessionId == user.SessionId);
            }
    
            public static bool ValidateCurrentLogin(User user)
            {
                return user != null && _sessions.Any(u => u.UserName == user.UserName && u.SessionId == user.SessionId);
            }
        }
    
        public class User {
            public string UserName { get; set; }
            public string SessionId { get; set; }
        }
