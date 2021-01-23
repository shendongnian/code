    from nSJL in UserList.AsEnumerable()
    join SJL in UserListOnline.AsEnumerable()
    on
    new { UserID = nSJL.Field<int>("UserID"),
          UserName = nSJL.Field<string>("UserName") }
    equals
    new { UserId = SJL.Field<int>("UserID"),
          UserName = SJL.Field<string>("UserName") }
    into sjList
