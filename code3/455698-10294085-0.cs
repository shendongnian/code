    from nSJL in UserList.AsEnumerable()
    join SJL in UserListOnline.AsEnumerable()
    on
    new{  UserID = nSJL.Field<int>("UserID"), UserName = nSJL.Field<string>("UserName") }
    equals
    new { UserID = nSJL.Field<int>("UserID"), UserName = nSJL.Field<string>("UserName") } into sjList
