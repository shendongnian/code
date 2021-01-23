    public void FreezeAllAccountsForUser(int userId, ILijosBankRepository accountRepository)
    {
      // your code as before
    }
    
    test ()
    {  var mockRepository = new Mock<ILijosBankRepository>();
        var service = // create object containing FreezeAllAccounts...
    
        service.FreezeAllAccounts(SOME_USER_ID, mockRepository);
    
        mock.Verify(r => r.GetAllAccountsForUser(SOME_USER_ID);
        mock.Verify(r => r.Update());
    }
