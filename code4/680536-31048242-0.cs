     public class ApplicationInfo
    {
            public List<ApplicationAccessRoles> ApplAccessRoleInfo { get; set; }
        }
     public class ApplicationAccessRoles
    {
        public int app_access_role_key { get; set; }
        public int app_key { get; set; }
        public string access_role { get; set; }
        public bool inactive { get; set; }
    }
