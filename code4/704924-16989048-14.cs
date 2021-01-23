    public class SecurityChecker : OnMethodBoundaryAspect
    {
        IPermissionsChecker _checker;
        public override void OnEntry(MethodExecutionArgs args) 
        { 
            if (!_checker.HasPermissions(Thread.CurrentThread))
                throw new SecurityException("No permissions");
        }
    }
