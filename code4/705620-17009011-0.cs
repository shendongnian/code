	    var userFromDb = db.Users.Where(u => u.UserID == user.UserID).First();
	    user.Password = person.Password;
        user.VerifyPassword = person.VerifyPassword;
	    db.Entry(person).CurrentValues.SetValues(user);
        db.SaveChanges();
