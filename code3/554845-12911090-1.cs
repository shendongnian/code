        UserBDCon db = new UserBDCon();
        var userLogin = new UserLogin() {LoginName = "Admin", Password = new byte()};
        var details = new UserDetails() {Address = "Address", UserName = "Admin", UserLogin = userLogin};
        var type = new UserType() {TypeDiscription = "Description", TypeName = "TypeName", UserLogin = userLogin};
        db.logins.Add(userLogin);
        db.Detail.Add(details);
        db.Type.Add(type);
        db.SaveChanges(); // EF insert data into 3 table at a time
