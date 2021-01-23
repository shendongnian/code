    Telerik.OpenAccess.Data.Common.OAConnection dbConnection = dbContext.Connection;
    LookUpType l = new LookUpType();
    l.IsActive = true;
    l.Name = "test123";
    
    LookUpType lkup = new LookUpType();
    lkup.IsActive = true;
    lkup.Name = "someTest";
                    
    dbContext.Add(new LookUpType[] { l, lkup });
    dbContext.SaveChanges();
