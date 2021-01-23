    public class UserPermissionViewModel : ViewModelBase
    {
        public UserPermissionViewModel(UserPermissions permission, bool isSet)
        {
            Permission = permission;
            IsSet = isSet;
        }
        public UserPermissions Permission { get; private set; }
        public bool IsSet { get; set; }
    }
