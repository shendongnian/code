    private MyDb db = new MyDb();
    
    public bool UserExists(string userName, string password){
    
       return db.Users.Any(x => x.user_name.Equals(userName, StringComparison.InvariantCultureIgnoreCase)
                             && x.password.Equals(password, StringComparison.InvariantCultureIgnoreCase));
    }
