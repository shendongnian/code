    public string getPassword()
    {
       DataClasses1DataContext myDbContext = new DataClasses1DataContext(dbPath);
    
       var password = (from user in myDbContext.Accounts
                       where user.accnt_User == txtUser.Text
                       select user.accnt_Pass).FirstOrDefault();
    
       if (password == null) 
       {
          // no data found - do whatever is needed in that case...
       }
    
       return password;
    }
