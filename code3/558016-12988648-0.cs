    var assignUsers = accountApp.GetUsersByAccountId(context.GetUserData().AccountId)
                                .Select(u => new { u.UserId, u.Name });
    
    var assignedUsers = mailApp.GetMailAssignedByMailId(id)
                               .Select(m => new { m.UserId, m.User.Name });
    
    var assignUsers = assignUser.Except(assignedUsers);
    // do not map until here
    List<AssignUserViewModel> result = 
                 assignUsers.Select(Mapper.DynamicMap<AssignUserViewModel>).ToList();
