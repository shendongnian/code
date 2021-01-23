    using (var session = new SessionScope())
    {
        using (Transaction = new TransactionScope(TransactionMode.New,  OnDispose.Commit))
        {
            try
            {
                class.Create();
                Transaction.VoteCommit();
            }
            catch (Exception ex)
            {
                Transaction.VoteRollBack();
                throw new Exception(ex.Message);
            }
        }
    }
