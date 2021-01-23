        public void CreateLogin(string name, string password, string defaultDatabase, string[] roles)
        {
            Login login = new Login(_server, name);
            login.LoginType = LoginType.SqlLogin;
            login.DefaultDatabase = defaultDatabase;
            
            login.PasswordExpirationEnabled = false;
            login.PasswordPolicyEnforced = false;
            login.Create(password, LoginCreateOptions.None);
            
            for (int i = 0; i < roles.Length; i++)
                login.AddToRole(roles[i]);
            
            login.Alter();
            
            login.Enable();
            login.Alter();
        }
