    public void LogIn(string email,string nameAndSurname)
    {
        LogInEntities logIndb = new LogInEntities();
        LogIn logIn = new LogIn();
        logIndb.LogIn = new List<LogIn>(); // Add this line to your code
        // Btter way is to initialize this list in constructor of LogInEntities
        if(ModelState.IsValid)
        {
            logIn.Email = email;
            logIn.NameAndSurname = nameAndSurname;
            logIndb.LogIn.Add(logIn);
            logIndb.SaveChanges();
        }
    }
