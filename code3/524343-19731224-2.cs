    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = true)]
    public sealed class MyClaimsPrincipalPermissionAttribute : CodeAccessSecurityAttribute
    {
        public Operations Operation { get; set; }
        public Resources Resource { get; set; }
    
        public MyClaimsPrincipalPermissionAttribute(SecurityAction action)
            : base(action)
        {
        }
    
        public override IPermission CreatePermission()
        {
            return new ClaimsPrincipalPermission(this.Resource.ToString(), this.Operation.ToString());
        }
    }
