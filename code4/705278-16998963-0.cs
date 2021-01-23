    class AuthenticatedConnection : Connection
    {
        public AuthenticatedConnection1(string token, object client)
            : base(client)
        {
            // use token etc
        }
    }
