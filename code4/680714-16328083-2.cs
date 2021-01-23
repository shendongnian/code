        var missingGroups = new Dictionary<String, List<String>>();
        var missingUsers = new Dictionary<String, List<String>>();
        allUsers.ForEach(u =>
        {
            // get the list where the group exists but this user isn't in it
            var groupsThisUserIsntIn = allGroups
                .Where(g => u.MemberOf.Contains(g.Name) && !g.Members.Contains(u.UserName))
                .Select(g => g.Name).ToList();
            // add in the groups this user says he belongs to but that aren't in allGroups
            groupsThisUserIsntIn.AddRange(u.MemberOf.Where(userGroupName => allGroups.All(g => g.Name != userGroupName)));
            if (groupsThisUserIsntIn.Count() > 0)
                missingUsers.Add(u.UserName, groupsThisUserIsntIn);
        });
        allGroups.ForEach(g =>
        {
            // get the list where the user exists but this group isn't in it
            var usersNotInThisGroup = allUsers
                .Where(u => g.Members.Contains(u.UserName) && !u.MemberOf.Contains(g.Name))
                .Select(u => u.UserName).ToList();
            // add in the users this group says it has but that aren't in allUsers 
            usersNotInThisGroup.AddRange(g.Members.Where(groupUserName => allUsers.All(u => u.UserName != groupUserName)));
            if (usersNotInThisGroup.Count() > 0)
                missingGroups.Add(g.Name, usersNotInThisGroup);
        });
