    public class MockPermissionsChecker : IPermissionsChecker
    {
        public bool HasPermissions(Thread thread)
        {
            return true;
        }
    }
