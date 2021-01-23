    // Would throw in case of error
    Guid Authenticate(strign name, string password);
    enum AuthenticateStatus
    {  
       Success,
       InvalidPassword
    }
    class AuthenticateExceptionEventArgs : EventArgs
    {
        public AuthenticateStatus Status { get; private set;
        public string ErrorMessage { get; private set; }
    }
