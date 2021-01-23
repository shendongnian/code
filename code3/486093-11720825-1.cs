    using (TransactionScope scope = new TransactionScope())
    {
        formview1.Connection.EnlistTransaction(Transcation.Current);
        formview2.Connection.EnlistTransaction(Transcation.Current);
        formview1.updateItem(true);
        formview2.updateItem(true);
        scope.Complete();
    }
