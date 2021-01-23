    //Gets the list of permissions for this user
            static IEnumerable<BusinessUnit> GetPermissions(int userID)
            {
                //create a permission tree result set object
                List<BusinessUnit> permissionTree = new List<BusinessUnit>();
    
                //Get the list of records for this user from UserPermissions table
                IEnumerable<UserPermissions> userPermissions = from UP in UPs
                                             where UP.User.UserID == userID
                                             select UP;
    
                //for each entry in UserPermissions, build the permission tree
                foreach (UserPermissions UP in userPermissions)
                {
                    BuildPermissionTree(UP.BusinessUnit, permissionTree);
                }
                
                return permissionTree;
            }
    
    //recursive query that drills the tree.
            static IEnumerable<BusinessUnit> BuildPermissionTree(BusinessUnit pBU,List<BusinessUnit> permissionTree)
            {
                permissionTree.Add(pBU);
    
                var query = from BU in BUs
                            where BU.ParentBusinessUnit == pBU
                            select BU;
    
                foreach (var BU in query)
                {
                    BuildPermissionTree(BU,permissionTree);
                }
                return permissionTree;
            }
