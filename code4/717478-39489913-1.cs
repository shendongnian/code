    DbContextTransaction _transactionContext;
    _transactionContext = _Context.Database.BeginTransaction();
    _Context.Database.ExecuteSqlCommand("SET ANSI_WARNINGS OFF");
    //Start:Below code is project specific
    _Context.Entry(SBSB_SUBSC).State = entityState;
    status = status + _Context.SaveChanges();
    //End
    if (_transactionContext != null)
        _transactionContext.Dispose();
