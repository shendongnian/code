    [Authorize]
        [HttpPost]
        public ActionResult AddPermission(string parentPermissionName, string permissionName)
        {
            var pd = ServiceContext.PermissionService.permissionDao;
            Permission parentPermission = pd.GetPermissionByName(parentPermissionName);
            if (parentPermission == null) {
                parentPermission = pd.GetRoot();
            }
            if (parentPermission != null && !string.IsNullOrEmpty(permissionName) && !pd.PermissionExists(permissionName))//only add with a name
            {
                pd.AddPermission(parentPermission, permissionName);
            }
            //refresh data
            PermissionTree permissionTree = LoadTreeSQLHierarchy(null, false);//start at root
            return View("Permissions", permissionTree);
        }
