    IList<User> lstUser = (from building in db.GetTable<Building>()
                           join user in db.GetTable<User>()
                           on new
                           {
                               ID_BUILDING = building.ID,
                               ID_USER = building.ID_USER_RESPONSIBLE,
                               building.ID_MANAGER
                           }
                           equals new
                           {
                               ID_BUILDING = 4,
                               ID_USER = user.ID,
                               1
                           } into grpUser
                           from grp in grpUser.DefaultIfEmpty()
                           select new 
                           {
                               ID_USER = grp.ID
                            });
