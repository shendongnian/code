    Logins login = new Logins();
    login.UserId = model.UserName;
    login.SessionId = System.Web.HttpContext.Current.Session.SessionID;;
    login.LoggedIn = true;
    
    LoginsRepository repo = new LoginsRepository();
    repo.InsertOrUpdate(login);
    repo.Save();
