    public class PermissionsCheckerProvider
    {
        // make sure you set this at app startup, either to the mock or to the real checker
        public static PermissionsCheckerProvider Current { get; set;}
        public IPermissionsChecker GetChecker()
        {
        }
    }
