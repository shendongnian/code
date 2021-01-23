         private void CreateTeamRole()
        {
            SecuritySystemRole Role = ObjectSpace.FindObject<SecuritySystemRole>(new BinaryOperator("Name", "Team"));
            if (Role != null)
                return;
            Role = ObjectSpace.CreateObject<SecuritySystemRole>();
            Role.Name = "Team";
            Role.CanEditModel = true;
            Role.SetTypePermissions<SecuritySystemUser>(SecurityOperations.Read, SecuritySystemModifier.Allow);
            Role.SetTypePermissions<SecuritySystemRole>(SecurityOperations.Read, SecuritySystemModifier.Allow);
            Role.SetTypePermissions<TeamMember>(SecurityOperations.ReadWriteAccess, SecuritySystemModifier.Allow);
            Role.SetTypePermissions<TeamMember>(SecurityOperations.Navigate, SecuritySystemModifier.Allow);
            foreach (var item in System.Reflection.Assembly.GetAssembly(typeof(DevExpress.ExpressApp.Kpi.KpiDefinition)).GetTypes())
                if (item.IsSubclassOf(typeof(XPBaseObject)))
                    Role.SetTypePermissions(item, SecurityOperations.FullAccess, SecuritySystemModifier.Allow);
            Role.SetTypePermissions<XPWeakReference>(SecurityOperations.FullAccess, SecuritySystemModifier.Allow);
            foreach (var item in System.Reflection.Assembly.GetAssembly(typeof(BaseObject)).GetTypes())
            {
                if (item.IsSubclassOf(typeof(XPBaseObject)) && !item.Equals(typeof(TeamMember)))
                {
                    if (item.IsSubclassOf(typeof(RestrictedBaseObject)))
                    {
                        Role.SetTypePermissions(item, "Create;Navigate;Delete", SecuritySystemModifier.Allow);
                        Role.AddObjectAccessPermission(item, "!Restricted or [CreatedBy.Oid] = CurrentUserId()", SecurityOperations.ReadWriteAccess);
                    }
                    else
                        Role.SetTypePermissions(item, SecurityOperations.FullAccess, SecuritySystemModifier.Allow);
                }
            }
        }
