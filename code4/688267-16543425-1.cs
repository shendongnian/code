        public static class UserProvider
        {
            private static Func<User> currentUserDelegate = new Func<User>(NullUser);
            public static Func<User> CurrentUserDelegate
            {
                set
                {
                    currentUserDelegate = value;
                }
            }
            private static User NullUser()
            {
                return null;
            }
            public static User CurrentUser
            {
                get
                {
                    return currentUserDelegate();
                }
            }
        }
