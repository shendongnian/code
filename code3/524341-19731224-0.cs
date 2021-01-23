    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = true)]
    public sealed class MyClaimsPrincipalPermissionAttribute : CodeAccessSecurityAttribute
    {
        public string Operation { get; set; }
        public string Resource { get; set; }
    
        public MyClaimsPrincipalPermissionAttribute(SecurityAction action)
            : base(action)
        {
        }
    
        public override IPermission CreatePermission()
        {
            return new ClaimsPrincipalPermission(this.Resource, this.Operation);
        }
    }
