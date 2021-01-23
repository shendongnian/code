    public class SecurityChecker : OnMethodBoundaryAspect
    {
        private static IPermissionsChecker _checker;
        public static void InjectChecker(IPermissionsChecker checker)
        {
            // best put some code here to make sure this is only called once,
            // as well as doing thread synchronization
            if (_checker == null)
                _checker = checker;
        }
