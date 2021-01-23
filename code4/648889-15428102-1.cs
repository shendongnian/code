    var dtEnumerable = SqlDataBase.SqlGetTable("SELECT ID,UserID FROM TBL_UserT WHERE SID = " + 4663 + " AND UserID = '" + UserID + "'").AsEnumerable().ToList();
    
    var newVariable = dtEnumerable.Select(x => new { UserID = x.Field<string>("UserID"), ID = x.Field<string>("ID") });
    //We now have access to both!
    string firstUserID = newVariable.First().UserID;
    string firstID = newVariable.First().ID;
