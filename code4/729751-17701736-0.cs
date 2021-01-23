    public class MadamUserSecurityAuthority : IUserSecurityAuthority
    {
        public MadamUserSecurityAuthority()
        {
        }
        //This constructor is required
        public MadamUserSecurityAuthority(IDictionary options)
        {
        }
        public object Authenticate(string userName, object password, PasswordFormat format, IDictionary options, string authenticationType)
        {
            if (_yourAuthenticationService.isValid(userName, password.ToString()))
                return true;
            
            //Returning null means the authentication failed
            return null;
        }
        public string RealmName
        {
            get { return "MADAM"; }
        }
    }
