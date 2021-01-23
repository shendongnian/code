    /***************** Permission Groups And Keys *****************/
    public static class Permissions
    {
        [PermissionGroup(PermissionGroupCode.Invoice)]
        public enum Invoices
        {
            CreateInvoice = 1,
            UpdateInvoice = 2,
            RemoveInvoice = 3,
            ManageAttachments = 4
        }
        [PermissionGroup(PermissionGroupCode.UserAccounts)]
        public enum UserAccounts
        {
            Create = 1,
            ChangePassword = 2
        }
    }
    public enum PermissionGroupCode
    {
        Invoice = 1,
        UserAccounts = 2,
        Members = 3
    }
    /***************** Attributes & ActionFilters *****************/
    [AttributeUsage(AttributeTargets.Enum)]
    public class PermissionGroupAttribute : Attribute
    {
        private PermissionGroupCode _GroupCode;
        public PermissionGroupCode GroupCode
        {
            get
            {
                return _GroupCode;
            }
        }
    
        public PermissionGroupAttribute(PermissionGroupCode GroupCode)
        {
            _GroupCode = GroupCode;
        }
    }
    
    
    public class RequirePermissionAttribute : AuthorizeAttribute
    {
        private object _RequiredPermission;
    
        public RequirePermissionAttribute(object RequiredPermission)
            : base()
        {
            _RequiredPermission = RequiredPermission;
        }
    
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var permissionGroupMetadata = (PermissionGroupAttribute)_RequiredPermission.GetType().GetCustomAttributes(typeof(PermissionGroupAttribute), false)[0];
    
            var groupCode = permissionGroupMetadata.GroupCode;
            var permissionCode = Convert.ToInt32(_RequiredPermission);
    
            return HasPermission(currentUserId, groupCode, permissionCode);
        }
    }
