        var groupsWithUsersNotInThem = new Dictionary<Group, List<User>>();
        var usersWithGroupsTheyArentIn = new Dictionary<User, List<Group>>();
        allUsers.ForEach(u =>
            {
                var groupsThisUserIsntIn = groups.Where(g => !g.Members.Contains(u.UserName)).ToList();
                if (groupsThisUserIsntIn.Count() > 0)
                    usersWithGroupsTheyArentIn.Add(u, groupsThisUserIsntIn);
            });
        allGroups.ForEach(g =>
        {
            var usersNotInThisGroup = users.Where(u => !u.MemberOf.Contains(g.Name)).ToList();
            if (usersNotInThisGroup.Count() > 0)
                groupsWithUsersNotInThem.Add(g, usersNotInThisGroup);
        });
