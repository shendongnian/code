       public static void FormsLogin(this User user, bool persist)
        {
            FormsAuthentication.SetAuthCookie(user.DisplayName, persist);
            user.AddHistory("Login event.", HistoryType.Login, "SYSTEM");
            Users.OnUserLogin(user);
            SetLastActivity(user);
        }
        public static void FormsLogout(this User user)
        {
            FormsAuthentication.SignOut();
        }
