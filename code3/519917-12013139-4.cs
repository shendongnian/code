     public class ShellViewModel : Screen, IShell
        {
            public ShellViewModel()
            {
                LoginSuccessful = delegate { };
                Logout = delegate { };
            }
    
            public Action LoginSuccessful { get; set; }
            public Action Logout { get; set; }
    
            public void DoLogin()
            {
                LoginSuccessful();
            }
    
            public void DoLogout()
            {
                Logout();
            }
        }
