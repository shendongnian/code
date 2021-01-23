    string basestring = "student{0}@email.com";
    string userName = "Student{0}";
    
    using (Database dc = new Database())
    {
       
        for (int i = 0; i < 400; i++)
        {
             dc.Connection.Open();
            string email = string.Format(basestring,i);
            string sName = string.Format(userName, i);
            User u = new User(){ Name = sName, UserName = email, InstitutionUniqueID = email, Email = email, CreationDate=DateTime.Now, InstitutionsID=1, GUID= Guid.NewGuid() };
            dc.Users.InsertOnSubmit(u); 
            dc.SubmitChanges(System.Data.Linq.ConflictMode.FailOnFirstConflict);
            dc.Connection.Close();
        }
       
    }
