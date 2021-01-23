    public class LoginDialog 
    {
        private static string _user;
        // class members
        public  void RunDialog() 
        {
            _user = "Peter";
        }
        public static string User { get { return _user; } } 
    }
