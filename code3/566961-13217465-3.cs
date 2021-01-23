    public void LogIn(string email,string nameAndSurname)
    {
        LogInEntities logIndb = new LogInEntities();
        LogIn logIn = new LogIn();
        if(ModelState.IsValid)
        {
            logIn.Email = email;
            logIn.NameAndSurname = nameAndSurname;
            ***logIndb.LogIn.Add(logIn);***
            logIndb.SaveChanges();
        }
    }
