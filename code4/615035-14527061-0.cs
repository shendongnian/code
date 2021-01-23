    var result = AspMemmership // the collection of data from aspnetdb..aspnet_Membership table
        .Join(AspUsers,        // the collection of data from aspnetdb..aspnet_Users table
            m => m.UserId,
            u => u.UserId,
            (m, u) => u)
        .Join(AspUsersInRoles,
            u => u.UserId,
            ur => ur.UserId,
            (u, ur) => new
            {
                u.UserId,
                u.UserName,
                ur.RoleId
            })
        .Join(AspRoles,
            x => x.RoleId,
            r => r.RoleId,
            (x, r) => new
            {
                x.UserId,
                x.UserName,
                r.RoleName
            })
        .Join(MNT_Users,
            x => x.UserId,
            u => u.aspnet_UsersID,
            (x, u) => new
            {
                x.UserId,
                x.UserName,
                u.PersonId,
                r.RoleName
            })
        .Join(MNT_Persons,
            x => x.PersonId,
            p => p.Id,
            (x, p) => new
            {
                x.UserId,
                x.UserName,
                u.PersonId,
                Name = String.Format("{0},{1} {2}.", 
                    p.LastName, p.FirstName, p.MiddleName.Substring(0, 1)),
                r.RoleName
            })
