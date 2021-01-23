    interface IServer 
    {
        ISession Authenticate();
    }
    interface ISession 
    {
        IServer Server{get;}
        void Post();
        void Get();
    }
