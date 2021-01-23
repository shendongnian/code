    [AssociatedFilter(typeof(MyAuthorizationFilter))]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class MyAuthorizeAttribute : Attribute
    {
        public string Code { get; set; }
    }
