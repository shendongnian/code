    public class RequirePermissionAttribute : AuthorizeAttribute
    {
        private object _Permission;
    
        public RequirePermissionAttribute(object Permission)
            : base()
        {
            _Permission = Permission;
        }
    }
