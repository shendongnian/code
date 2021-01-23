    public class UserPermissionsViewModel
    {
        public UserPermissionsViewModel(UserPermissions permissions)
        {
            // Convert each flag of UserPermissions enum to UserPermissionViewModel and pass IsSet (true) if the permissions has the flag.
            Permissions = allPermissions.Select(singlePermission => new UserPermissionViewModel(singlePermission, permissions.HasFlag(singlePermission))).ToList();
        }
        public List<UserPermissionViewModel> Permissions
        {
            get;
            private set;
        }
        public UserPermissions Result
        {
            get
            {
                // Iterate over Permissions list and get result flags enum.
            }
        }
