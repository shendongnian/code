    public class PermissionsAttribute : ActionFilterAttribute
    {
        private readonly Permission _requiredPermission;
        public PermissionsAttribute(string itemName, Operation op)
        {
            var permi = new Permission()
            this._requiredPermission = permi;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var user = HttpContext.Current.User;
            if (user == null)
            {/*redirect to sign-in page*/}
            else
            {/*check permission/*}
        }
