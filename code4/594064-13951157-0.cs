    var query = from rStats in StatsTable.AsEnumerable()
                join rUser in UserTable.AsEnumerable()
                on rStats.Field<int>("UserID") equals rUser.Field<int>("UserID")
                select new {
                    UserID   = rStats.Field<int>("UserID"), 
                    UserName = string.Format("{0} {1}"
                                   , rUser.Field<string>("First_Name")
                                   , rUser.Field<string>("Last_Name"))
                };
    List<Tuple<int, string>> users = query
        .OrderBy(u => u.UserName)
        .Select(u => Tuple.Create(u.UserID, u.UserName))
        .ToList();
