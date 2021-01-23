    SqlConnection connection = null;
    // TODO: Get the connection object in an async fashion
    using (var scope = new TransactionScope()) {
        connection.EnlistTransaction(Transaction.Current);
        // ...
        // Do something with the connection/transaction.
        // Do not use async since the transactionscope cannot be used/disposed outside the 
        // thread where it was created.
        // ...
    }
