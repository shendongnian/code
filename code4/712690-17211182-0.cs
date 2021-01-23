    users = db.Users.Where(u => u.IsActive == true);
    if (txtFilterBy_UserName.Value.Length > 0))
    {
        users = users.Where(u => u.UserName.ToLower().Contains(txtFilterBy_UserName.Value.ToLower()));
    }
    users = users.ToList();
