    using (DataClasses1DataContext myDbContext = new DataClasses1DataContext(dbPath))
    {
        //Instantiate a new Hasher Object
        var hasher = new Hasher();
 
        hasher.SaltSize = 16;
        //Encrypts The password
        var encryptedPassword = hasher.Encrypt(txtPass.Text);
        Account newUser = new Account();
        newUser.accnt_User = txtUser.Text;
        newUser.accnt_Position = txtPosition.Text;
        newUser.accnt_Position = encryptedPassword;
        // Replace AccountTableName with the actual table
        // name found in your dbml's context
        myDbContext.AccountTableName.InsertOnSubmit(newUser);
        myDbContext.SubmitChanges();
    }
