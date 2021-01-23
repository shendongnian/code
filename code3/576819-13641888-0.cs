           ICriteria criteria = Session.CreateCriteria<User>()
                .CreateAlias("SecurityGroups", "SecurityGroups")
                .CreateAlias("SecurityGroups.Permissions", "Permissions")
                .Add(Restrictions.Eq("Permissions.Active", true))
                .Add(Restrictions.Eq("Active", true))
                .Add(Restrictions.In("Permissions.Site", ids.ToArray()))
                .Add(Restrictions.Eq("Permissions.Perm" + Enum.GetName(typeof(Perm.Types), accessRight), Perm.Level.Allow));
            return criteria.List<User>();
