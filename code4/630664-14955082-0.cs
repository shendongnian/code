    var result = _db.tbl_Users.Where(u=> u.Deleted == false).Select(e=> new
                        {
                            u.UserId,
                            u.UserName,
                            u.Email,
                            u.IsAdmin,
                            u.tbl_ServiceArea.ServiceArea,
                        }.ToList();
    foreach(var res in result)
    {
        if(res.IsAdmin)
        {
         // Do SOmething
        }
    }
