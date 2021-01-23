    var dtEnumerable = SqlDataBase.SqlGetTable("SELECT ID,UserID FROM TBL_UserT WHERE SID = " + 4663 + " AND UserID = '" + UserID + "'").AsEnumerable().ToList();
    
    var newVariable = dtEnumerable.Select(x => new { UserID = x.Field<string>("UserID"), ID = x.Field<string>("ID") });
    //Get new/old
    var states = newVariable.Select(x => new { IsNew = !listIDStr.Contains(x.UserId), IsUpdate = listIDSTr.Contains(x.UserID), ID = x.UserID });
    var updates = states.Where(x => x.IsUpdate).Select(x => x.UserID);
    var newIds = states.Where(x => x.IsNew).Select(x => x.UserID);
    //We now have access to both!
    string firstUserID = newVariable.First().UserID;
    string firstID = newVariable.First().ID;
