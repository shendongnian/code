    public class RequiredIfPermissionIdsAttribute : RequiredAttribute
    {
        public int[] PermissionIds { get; private set; }
        public RequiredIfPermissionIdsAttribute(params int[] permissionIds)
        {
            PermissionIds = permissionIds ?? new int[0];
        }
        public override bool IsValid(object value)
        {
            int permissionId = Helpers.ConvertToInt(Services.UserService.GetCurrentPermissionId().ToString());
            if (PermissionIds.Contains(permissionId))
            {
                return base.IsValid(value);
            }
            // the current permission id is not in the list of permission ids
            // that require validation => we consider the model valid
            return true;
        }
    }
