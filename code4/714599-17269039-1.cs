    var user = Membership.GetUser(userName, password);
    if (user.IsLocked) {
        Redirect();
    }
    else {
        Membership.LoginUser(user);
    }
... ?
