    public **permissionTemp** createPermissionObject(Guid userID, string username)
    {
        var objPermission = new permissionTemp();
        using (gedaiappEntities context = new gedaiappEntities())
        {        
           //Cria objeto global de permissões
            objPermission.userGuid = userID;
            //
            objPermission.grupos = Roles.GetRolesForUser(username);
            ....
            
            objPermission.permissoes = c.ToArray();
        }
        return objPermission;
    }
