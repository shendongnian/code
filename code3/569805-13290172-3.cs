    var EmpRecList = (from ur in db.Users
                      join ug in db.UserGroups on ur.UserGroupID equals ug.UserGroupID
                      select new
                      {
                          lastName = ur.LastName, 
                          userID = ur.UserID,
                          firstName = ur.FirstName,
                          userGroupName = ug.UserGroupNameLang1
                       })
                      .Where(oh => oh.userGroupName.StartsWith(userCur.UserGroupName))
                      .GroupBy(g => g.userID).Select(s => s.First()).ToList().OrderBy(x => x.lastName)
