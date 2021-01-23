    public class ModifiedAuthFilter : AuthorizeAttribute
    {
        [Dependency]
        public IRoleManager Manager { get; set; }
        public string DesiredRoles { get; set; }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            this.Roles = Manager.GetRealRoleNames(this.DesiredRoles);
            base.OnAuthorization(filterContext);
        }
    }
