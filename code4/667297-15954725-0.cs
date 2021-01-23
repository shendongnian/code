    public class Permission : ViewModelBase
    {
        private string displayName;
        private bool roleHasPermission;
        public string DisplayName
        {
            get
            {
                return this.displayName;
            }
            set
            {
                this.displayName = value;
                this.RaisePropertyChanged(() => this.DisplayName);
            }
        }
        public bool RoleHasPermission
        {
            get
            {
                return this.roleHasPermission;
            }
            set
            {
                this.roleHasPermission = value;
                this.RaisePropertyChanged(() => this.RoleHasPermission);
            }
        }
    }
