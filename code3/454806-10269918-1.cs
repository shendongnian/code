    UserData user = new UserData();
    
    user.Username = ...;
    user.Password = ...;
    user.Role = ...;
    user.Membership = ...;
    user.DateOfReg = ...;
    db.UserDatas.InsertOnSubmit(user);
    db.SubmitChanges();
