    public class AuthenticationResult
    {
        // will be Guid.Empty if unable to authenticate.
        public Guid SessionKey
        {
            get;
            set;
        }
        public bool Authenticated
        {
            get
            {
                return this.SessionKey != Guid.Empty
            }
        }
        // This will contain the login failure reason.
        public string FailureMessage
        {
            get;
            set;
        }
    }
