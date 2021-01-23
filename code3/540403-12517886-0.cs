        var userRoles = from MembershipUser user in Membership.GetAllUsers()
                        let roles = Roles.GetRolesForUser(user.UserName)
                        select new {
                            UserName = user.UserName, 
                            Email = user.Email,
                            Roles = string.Join(", ",  roles) };
