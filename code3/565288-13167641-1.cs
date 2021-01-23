    public static class Roles
    {
        protected static Lazy<MyCustomProvider> _provider = new Lazy<MyCustomProvider>(() => System.Web.Security.Roles.Provider);
        public static MyCustomProvider Provider { get { return _provider.Value; } }
        public static IsUserInRole(string userName, string roleName)
        {
            return _provider.Value.IsUserInRole(userName, roleName);
        }
        public static MyCustomFunction()
        {
            return _provider.Value.MyCustomFunction();
        }
    }
