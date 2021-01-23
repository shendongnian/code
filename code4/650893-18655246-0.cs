    var testUsers = Users.Where (a => a.login.StartsWith("test")); 
    testUsers.Dump();
    foreach (var user in testUsers) {
    	MyExtensions.PatchForDelete(user);	
    	AsdBenutzers.DeleteOnSubmit(user);	
    }
    SubmitChanges();
