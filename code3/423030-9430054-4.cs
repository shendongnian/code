    enum AuthenticateStatus
    {  
       Success,
       InvalidPassword
    }
    class AuthenticateExceptionEventArgs : EventArgs
    {
        public AuthenticateStatus Status { get; private set;
    }
