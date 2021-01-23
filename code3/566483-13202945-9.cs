    public static MyAuthorizations GetMyAuthorizations(IEnumerable<MethodInfo> actions)
    {
        var myAuthorization = new MyAuthorizations();
        foreach (var methodInfo in actions)
        {
            var authorizationAttributes =  methodInfo
                    .GetCustomAttributes(typeof (MyAuthorizationAttribute), false)
                    .Cast<MyAuthorizationAttribute>();
            foreach (var myAuthorizationAttribute in authorizationAttributes)
            {
                myAuthorization.Roles.Add(MyAuthorizationAttribute.Role);
                myAuthorization.Permissions.Add(MyAuthorizationAttribute.Permission);
            }
        }
        return myAuthorization;
    }
    public class MyAuthorizations
    {
        public MyAuthorizations()
        {
            Roles = new List<string>();
            Permissions = new List<string>();
        }
        public List<string> Roles { get; set; }
        public List<string> Permissions { get; set; }
    }
