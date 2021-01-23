    Permissions = 
        new Func<DataRow, List<Permission>>(permissionData =>
        {
            List<Permission> permissions = new List<Permission>();
            // do all your if checks here to add the necessary permissions to the list
            return permissions;
        })(data[0])
