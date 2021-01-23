    bool ICustomPermissions.AddPermissionsToRole(RoleDataContract role, List<PermissionDataContract> permissions)
        {
           using(_context = new RolePermissionMappingContainer())
           {
                   foreach (PermissionDataContract pdc in permissions)
                   {
                       RolePermissionMapping rpm = new RolePermissionMapping()
                       {
                           RoleId = role.RoleId,
                           PermissoinId = pdc.PermissionId
                       }
                       _context.RolePermissionMappings.AddObject(rpm);
                       _context.SaveChanges();
                   }
           }
           return true;
        }
