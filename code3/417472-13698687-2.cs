        var db = new MainDataContext();
        var user = new User
        {
            Name = "someUser",
            Password = "somePassword",
            Email = "someEmail"
        };
        db.Users.Add(user);
        db.SaveChanges();
        // After some time in other some place
        var user = db.GetPersonFromDb(Id);// Get early saved person from db
        var information = new UserInfo
        {
             FirstName = "someFirstName",
             LastName = "someLastName",
        }
        user.Information = information;
        db.SaveChanges();
