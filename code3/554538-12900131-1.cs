    public class NotRequiredIfPermissionIdsAttribute : RequiredAttribute
    {
        public NotRequiredIfPermissionIdsAttribute(params int[] permissionIds)
        {
            PermissionIds = permissionIds ?? new int[0];
        }
        public int[] PermissionIds { get; private set; }
        public override bool IsValid(object value)
        {
            int permissionId = Helpers.ConvertToInt(Services.UserService.GetCurrentPermissionId().ToString());
            if (!PermissionIds.Contains(permissionId))
            {
                return base.IsValid(value);
            }
            return true;
        }
    }
