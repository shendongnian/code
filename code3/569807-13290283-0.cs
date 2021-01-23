    var EmpRecList = (from ur in db.Users
      let groups = db.UserGroups.Where(ug => ur.UserGroupID == ug.UserGroupID)
      select new
      {
          lastName = ur.LastName, 
          userID = ur.UserID,
          firstName = ur.FirstName,
          userGroupNames = groups.Select(g => g.UserGroupNameLang1)
      }).Where(oh => oh.userGroupNames.Any(n => n.StartsWith(userCur.UserGroupName)))
                                      .OrderBy(x => x.lastName);
