    var cookie = context.Request.Cookies[FormsAuthentication.FormsCookieName];
    dynamic UN = FormsAuthentication.Decrypt(cookie.Value);
    string UserData = UN.UserData;//PID, BusName, FirstName, LastName, imgUrl, Role, IsAct
    string[] pFields = UserData.Split('|');
    string[] MyRoles = { pFields[5] };
    
